using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float StartSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float Starthealth = 100;
    float health;
    public int MoneyVal = 50;

    public Image HealthBar;
    public GameObject deathEffect;

    bool isDead=false;
    private void Start()
    {
        speed= StartSpeed;
        health= Starthealth;
    }
    public void TakeDamage(float Damageamount)
    {
        health -= Damageamount;
        HealthBar.fillAmount = health/100f;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        PlayerStats.Money += MoneyVal;
        GameObject deathEff=(GameObject)Instantiate(deathEffect,transform.position,transform.rotation);
        Destroy(deathEff,4f);
        Destroy(gameObject);
        Spawner.EnemiesAlive--;
    }
    public void slow(float slowAmount)
    {
        speed = StartSpeed* (1f - slowAmount);
    }
}
