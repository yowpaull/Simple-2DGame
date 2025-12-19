using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        Time.timeScale = 1f;

        ScoreTextScript.coinAmount = 0;

        SceneManager.LoadScene("Stage1");
    }

    public void Quit()
    {

        ScoreTextScript.coinAmount = 0;

        SceneManager.LoadScene("StartScene");
    }
}