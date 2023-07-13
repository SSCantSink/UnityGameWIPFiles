using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovLR : MonoBehaviour
{

    public Rigidbody2D rb;
    public float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(maxSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -4f)
        {
            rb.velocity = new Vector2(maxSpeed, 0);
        }
        if (transform.position.x > 4f)
        {
            rb.velocity = new Vector2(-maxSpeed, 0);
        }
    }
}
