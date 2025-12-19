using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int Stage2;

    private void OnTriggerEnter2D(Collider2D other)
    {

   if(other.tag == "Player")
        {
            SceneManager.LoadScene(Stage2, LoadSceneMode.Single);
        }

            }



}
