using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAAI : MonoBehaviour
{
    public float minShootTime;
    public float maxShootTime;
    float shootTime;

    [Header("References")]
    public Animator animator;
    public GameObject bulletPrefab;
    GameObject player;
    AudioManager sounds;

    // Start is called before the first frame update
    void Start()
    {
        shootTime = Random.Range(minShootTime, maxShootTime);
        player = GameObject.FindGameObjectWithTag("Player");
        sounds = FindObjectOfType<AudioManager>();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        sounds.Play("EnemyShoot");
    }

    // Update is called once per frame
    void Update()
    {
        if ((player != null) && shootTime > 0f)
        {
            shootTime -= 1f * Time.deltaTime;
            animator.SetFloat("timeB4Shoot", shootTime);
        }

        if ((player != null) && shootTime <= 0f)
        {
            Shoot();
            shootTime = Random.Range(minShootTime, maxShootTime);
            animator.SetFloat("timeB4Shoot", shootTime);
        }
    }
}
