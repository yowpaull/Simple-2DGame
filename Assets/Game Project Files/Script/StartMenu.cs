using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Stage1"); 
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitGame()
    {
        Debug.Log("Game is Exiting...");
        Application.Quit();
    }
}