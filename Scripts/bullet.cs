using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Transform target;
    public float speed = 60f;
    public float explosionRange=0f;
    public int damage = 50;
    public GameObject impactEffect;
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float speedThisFrame = speed*Time.deltaTime;
        if(dir.magnitude <= speedThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*speedThisFrame,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject bulletEff = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(bulletEff,5f);
        if (explosionRange>0f)
        {
            explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);

    }
    void explode()
    {
        Collider[]colliders = Physics.OverlapSphere(transform.position,explosionRange);
        foreach (Collider collider in colliders)
        {
            if(collider.tag =="Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform e)
    {
        Enemy enemy = e.GetComponent<Enemy>();
        if(enemy != null) 
          enemy.TakeDamage(damage);
    }
    public void Seek(Transform target)
    {
        this.target = target;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,explosionRange);
    }
}
