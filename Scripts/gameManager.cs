using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public static bool GameOver ;
    public GameObject gameOverUI;
    public GameObject LevelCompleteUI;
    private void Start()
    {
        GameOver = false;
    }
    void Update()
    {
        if (GameOver)
            return;
        
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameOverUI.SetActive(true);
        GameOver = true;
    }
    public void LevelWin()
    {
        GameOver = true;
        LevelCompleteUI.SetActive(true);
    }
}
