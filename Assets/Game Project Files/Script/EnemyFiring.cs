using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public AudioClip fireSound;

    private float timer;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        if (fireSound != null)
        {
            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }

        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}