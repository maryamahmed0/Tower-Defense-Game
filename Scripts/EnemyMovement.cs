using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform Target;
    int PointIndex = 0;
    Enemy enemy;

    void Start()
    {
        Target = WayPoints.Points[0];
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed*Time.deltaTime,Space.World);
        float distance = Vector3.Distance(transform.position, Target.position);
        if (distance < 0.2f)
        {
            NextWayPoint();
        }
        enemy.speed = enemy.StartSpeed;
    }
    void NextWayPoint()
    {
        if(PointIndex>=WayPoints.Points.Length+1)
        {
            EndPath();
            return;

        }
        PointIndex++;
        Target = WayPoints.Points[PointIndex];
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        Spawner.EnemiesAlive--;
    }
    
}
