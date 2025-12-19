using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; 


    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0f;
    }


    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(1);
        ScoreTextScript.coinAmount = 0;
    }

    public void BackToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        ScoreTextScript.coinAmount = 0;
    }
}