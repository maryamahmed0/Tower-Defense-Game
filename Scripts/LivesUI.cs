using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text LivesTxt;
    void Update()
    {
        LivesTxt.text = PlayerStats.Lives + " Lives";
    }
}
