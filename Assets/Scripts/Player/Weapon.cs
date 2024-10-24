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

    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Shoot.performed += ctx => Shoot();
    }

    private void Start()
    {
        sounds = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // shoot when player presses space and no downtime.
        /*if (Input.GetButtonDown("Fire1") && delay <= 0 && !PauseMenu.GameIsPaused)
        {
            Shoot();
            delay = maxDelay;
        }*/

        // if there is downtime
        if (delay > 0f)
        {
            delay -= Time.deltaTime;
        }

    }

    void Shoot()
    {

        if (delay <= 0 && !PauseMenu.GameIsPaused)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            sounds.Play("PlayerShoot");
            delay = maxDelay;
        }
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
