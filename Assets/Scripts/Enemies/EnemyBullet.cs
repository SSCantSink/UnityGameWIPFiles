using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 40;
    public float lifeTime = 1f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // instantiate the player found by bullet.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // calculate direction to fly towards player.
        float xDir = player.position.x - gameObject.transform.position.x;
        float yDir = player.position.y - gameObject.transform.position.y;
        Vector2 dir = new Vector2(xDir, yDir);
        Vector2 normDir = dir.normalized;

        // adjust the velocity of the bolito
        rb.velocity = normDir * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        // see if enemy gets hit and make it take damage.
        if (hitInfo.CompareTag("Player"))
        {
            PlayerStats theThing = hitInfo.GetComponent<PlayerStats>();
            theThing.TakeDamage(damage);

            // create the animation upon collsion
            Instantiate(impactEffect, transform.position, transform.rotation);

            // destroy the actual bullet.
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // destroys bullet if it has been running too long.
        if (lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
}
