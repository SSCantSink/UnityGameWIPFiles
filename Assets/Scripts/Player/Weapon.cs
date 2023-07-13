using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float maxDelay;
    float delay = 0f;

    AudioManager sounds;

    private void Start()
    {
        sounds = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // shoot when player presses space and no downtime.
        if (Input.GetButtonDown("Fire1") && delay <= 0)
        {
            Shoot();
            delay = maxDelay;
        }

        // if there is downtime
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        sounds.Play("PlayerShoot");
    }
}
