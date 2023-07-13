using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [ Header ("Stats")]
    public int health = 100;
    public float iFrames;
    public float maxIFrames;

    [Header ("References")]
    public Animator animator;
    public GameObject explosionAnimation;
    LootTable loot;

    GameObject player;
    AudioManager sounds;

    private void Start()
    {
        loot = GetComponent<LootTable>();
        sounds = FindObjectOfType<AudioManager>();
    }

    public void Spawn(float x, float y)
    {
        Instantiate(gameObject, new Vector3(x, y), Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        // only take damage if you don't have i frames.
        if (iFrames <= 0)
        {
            animator.SetFloat("hurtTime", maxIFrames);    // make sure animation goes boom boom.
            health -= damage;
            sounds.Play("EnemyHurt");
            iFrames = maxIFrames;
        }
        else
        {
            sounds.Play("HurtIFrames");
        }

        // if health is 0 or negative, just die my dude.
        if (health <= 0)
        {
            Die();
        }
    }

    public void Update()
    {
        // Update the iframes this thing might have.
        if (iFrames > 0f)
        {
            iFrames -= 1f * Time.deltaTime;
            animator.SetFloat("hurtTime", iFrames);
        }
        
    }

    void Die()
    {
        Instantiate(explosionAnimation, transform.position, Quaternion.identity);
        loot.DropLoot();
        sounds.Play("EnemyExplosion");
        Destroy(gameObject);
    }
}
