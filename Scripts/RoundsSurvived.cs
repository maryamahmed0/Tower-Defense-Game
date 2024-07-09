using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text Roundtxt;
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

   IEnumerator AnimateText()
    {
        Roundtxt.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.5f);
        while (round<PlayerStats.Rounds)
        {
            round++;
            Roundtxt.text = round.ToString();   
            yield return new WaitForSeconds(0.05f);
        }
    }
}
