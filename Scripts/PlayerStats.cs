using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 400;

    public static int Lives;
    public int StartLives = 5;
    public static int Rounds;
    private void Start()
    {
        Money = StartMoney;
        Lives = StartLives;
        Rounds = 0;
    }

}
