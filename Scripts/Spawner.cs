using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Waves[] waves;
    public float CountDown = 2f;
    public float TimeBetweenWaves = 5f;
    int WaveIndex = 0;
    public Transform SpawnPos;
    public Text WaveCountDown;

    public static int EnemiesAlive;
    public gameManager manager;
    void Update()
    {
        if(EnemiesAlive >0)
            return;
        if (WaveIndex == waves.Length)
        {
            manager.LevelWin();
            this.enabled = false;
        }

        if (CountDown <=0)
        {
            StartCoroutine(SpawnWaves());
            CountDown = TimeBetweenWaves;
            return;
        }
        CountDown -=Time.deltaTime;

        CountDown = Mathf.Clamp(CountDown, 0f, Mathf.Infinity);
        WaveCountDown.text = string.Format("{0:00.00}" , CountDown);
    }
    IEnumerator SpawnWaves()
    {
        Waves wave = waves[WaveIndex];
        PlayerStats.Rounds++;
        EnemiesAlive = wave.count;  
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        WaveIndex++;
      
    }
    void SpawnEnemy(GameObject Enemy)
    {
        Instantiate(Enemy,SpawnPos.position,SpawnPos.rotation);
        
    }
}
