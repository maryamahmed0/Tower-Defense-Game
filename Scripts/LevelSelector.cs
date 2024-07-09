using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] LevelButton;
    
    private void Start()
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached", 1);
        for (int i = 0; i < LevelButton.Length; i++)
        {
            if (i+1>LevelReached)
            {
                LevelButton[i].interactable = false;
            }
        }
    }
    public void SelectLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
