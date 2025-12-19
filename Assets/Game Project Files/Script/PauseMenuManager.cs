using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) Resume();
            else Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadNewGame()
    {
        Time.timeScale = 1f; 
        ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("Stage1");
    }

    public void ExitToTitle()
    {
        Time.timeScale = 1f;
        ScoreTextScript.coinAmount = 0;
        SceneManager.LoadScene("StartScene");
    }
}