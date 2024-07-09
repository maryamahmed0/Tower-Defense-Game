using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text MoneyTxt;
    void Update()
    {
        MoneyTxt.text = '$' + PlayerStats.Money.ToString();
    }
}
