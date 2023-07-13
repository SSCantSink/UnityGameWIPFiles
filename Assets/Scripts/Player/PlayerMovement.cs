using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // the player rigid body.
    public Rigidbody2D rb;

    // player's Transform
    public Transform player;

    // player's max speed.
    public float maxSpeed;

    void FixedUpdate()
    {
        // checks wasd for inputs and pushes player along that.
        
        if (Input.GetKey("d") && rb.velocity.x < maxSpeed)
        {
            rb.AddForce(new Vector2(100f, 0f));
        }
        
        if (Input.GetKey("a") && rb.velocity.x > -maxSpeed)
        {
            rb.AddForce(new Vector2(-100f, 0f));
        }

        if (Input.GetKey("w") && rb.velocity.y < maxSpeed)
        {
            rb.AddForce(new Vector2(0f, 100f));
        }

        if (Input.GetKey("s") && rb.velocity.y > -maxSpeed)
        {
            rb.AddForce(new Vector2(0f, -100f));
        }
        
    }

}
