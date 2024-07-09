using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public float range =15f;
    Transform target;
    Enemy targetEnemy;
    public Transform PartToRotate;
    public float RotationSpeed = 10f;
    public float fireRate = 1f;
    float FireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform FirePos;

    // laser 
    public bool useLaser = false;
    public LineRenderer LineRenderer;
    public int LaserDamage = 30;
    public float slowAmount = 0.5f;
    public ParticleSystem impactEffect;
    public Light laserLight;

    void Start()
    {
        InvokeRepeating("UpadteTarget", 0f, 0.5f);
    }
    void Update()
    {
        if (target == null)
        {
            if (useLaser) 
            { 
               if(LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;   
                    impactEffect.Stop();
                    laserLight.enabled = false;
                }
            }

            return;
        }
            
        LookOnTarget();
        if(useLaser)
        {
            Laser();
        }
        else
        {
            useBullet();
        } 
    }
    void useBullet()
    {
        if (FireCountDown <= 0f)
        {
            Shoot();
            FireCountDown = 1f / fireRate;
        }
        FireCountDown -= Time.deltaTime;
    }
    void Laser()
    {
        targetEnemy.TakeDamage(LaserDamage * Time.deltaTime);
        targetEnemy.slow(slowAmount);

        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            impactEffect.Play();
            laserLight.enabled = true;
        }
        LineRenderer.SetPosition(0,FirePos.position);
        LineRenderer.SetPosition(1,target.position);

        Vector3 dir = FirePos.position - target.position;
        impactEffect.transform.position = target.position+dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
    void LookOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion LookRotation = Quaternion.LookRotation(dir);
        Vector3 Rotaion = Quaternion.Lerp(PartToRotate.rotation, LookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, Rotaion.y, 0f);
    }
    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, FirePos.transform.position, FirePos.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();
        if(bullet != null) 
          bullet.Seek(target);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    void UpadteTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortesetDis = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortesetDis)
            {
                shortesetDis = distance;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortesetDis <= range)
        {
            target= nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
}
