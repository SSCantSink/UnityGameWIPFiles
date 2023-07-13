using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // health of the player
    public int health;
    public int maxHealth = 200;

    // time of I Frames
    float iFrames = 0f;
    public float maxIFrames = 1f;

    public Animator animator;

    public HealthBar healthBar;

    public GameObject explosionAnimation;

    AudioManager sounds;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        sounds = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iFrames > 0)
        {
            iFrames -= 1f * Time.deltaTime;
            animator.SetFloat("hurtTime", iFrames);
        }
    }

    public void TakeDamage(int damage)
    {
        // only take damage if you don't have i frames.
        if (iFrames <= 0)
        {
            animator.SetFloat("hurtTime", maxIFrames);    // make sure animation goes boom boom.
            health -= damage;
            healthBar.SetHealth(health);
            iFrames = maxIFrames;
            sounds.Play("PlayerHurt");
        }
        else
        {
            sounds.Play("HurtIFrames");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // cause an explosion and DIE
        Instantiate(explosionAnimation, transform.position, Quaternion.identity);
        Destroy(gameObject);

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
    }
}
