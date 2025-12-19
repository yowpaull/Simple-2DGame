using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip keySound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            if (keySound != null)
            {
                AudioSource.PlayClipAtPoint(keySound, transform.position);
            }

            // UNLOCK GATE
            Lock.instance.UnlockDoor();
            Destroy(gameObject);
        }
    }
}