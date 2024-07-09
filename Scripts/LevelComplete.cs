using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string NextLevel = "Level2";
    public int LevelIndex = 2;
    public void Continue()
    {
        PlayerPrefs.SetInt("LevelReached", LevelIndex);
        SceneManager.LoadScene(NextLevel);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
