using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        PauseMenuUI.SetActive(!PauseMenuUI.activeSelf);
        if (PauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        { 
            Time.timeScale = 1f;
        }

    }
    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
