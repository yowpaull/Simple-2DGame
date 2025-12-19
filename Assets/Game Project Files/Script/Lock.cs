using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static Lock instance;

    [SerializeField]
    public float scaleTime = 1f;

    [Header("Audio Settings")]
    public AudioClip doorOpenSound; 

    private Vector3 myScale;
    private bool keyCollected, canScale;
    private BoxCollider2D myCollider;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Unlock();
    }

    void Unlock()
    {
        if (keyCollected && canScale)
        {
            myScale = transform.localScale;
            myScale.y -= scaleTime * Time.deltaTime;

            if (myScale.y <= 0f)
            {
                myScale.y = 0f;
                myCollider.enabled = false;
                canScale = false;
            }

            transform.localScale = myScale;
        }
    }

    public void UnlockDoor()
    {
        keyCollected = true;
        canScale = true;

        if (doorOpenSound != null)
        {
            AudioSource.PlayClipAtPoint(doorOpenSound, transform.position);
        }
    }
}