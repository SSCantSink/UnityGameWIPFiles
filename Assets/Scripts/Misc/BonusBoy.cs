using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBoy : MonoBehaviour
{

    public int health;

    public float maxIFrames;
    float iFrames = 0f;

    AudioManager sounds;

    public GameObject explosionAnimation;
    LootTable loot;

    public void TakeDamage(int damage)
    {
        // only take damage if you don't have i frames.
        if (iFrames <= 0)
        {
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

    // Start is called before the first frame update
    void Start()
    {
        loot = GetComponent<LootTable>();
        sounds = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the iframes this thing might have.
        if (iFrames > 0f)
        {
            iFrames -= 1f * Time.deltaTime;
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
