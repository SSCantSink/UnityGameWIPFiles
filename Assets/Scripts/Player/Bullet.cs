using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {

        // see if enemy gets hit and make it take damage.
        if (hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            enemy.TakeDamage(damage);

            // create the animation upon collsion
            Instantiate(impactEffect, transform.position, transform.rotation);
            // destroy the actual bullet.
            Destroy(gameObject);
        }

        if (hitInfo.CompareTag("BonusBoy"))
        {
            BonusBoy enemy = hitInfo.GetComponent<BonusBoy>();

            enemy.TakeDamage(damage);

            // create the animation upon collsion
            Instantiate(impactEffect, transform.position, transform.rotation);
            // destroy the actual bullet.
            Destroy(gameObject);
        }
    }

    private void Update()
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
