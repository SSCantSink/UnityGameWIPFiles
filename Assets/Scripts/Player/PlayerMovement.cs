using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // the player rigid body.
    public Rigidbody2D rb;

    // player's Transform
    public Transform player;

    // player's max speed.
    public float maxSpeed;

    // players' max dash speed
    public float maxDashSpeed;

    PlayerControls controls;

    Vector2 move;

    float dashTime;
    float dashDelay;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        controls.Gameplay.Dash.performed += ctx => Dash();

        // how long the user must wait in order to move after dashing.

        dashTime = 0;
        dashDelay = 0;

    }

    /*void FixedUpdate()
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
        
    }*/

    private void Update()
    {
        
        /*float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movementInput = new Vector2(horizontalInput, verticalInput).normalized;
        Vector2 mouseMovementVelocity = movementInput * maxSpeed;*/

        Vector2 m = new Vector2(move.x, move.y) * maxSpeed;

        // only change velocity if not dashing.
        if (dashTime <= 0)
        {
            rb.velocity = m;
        }

        if (dashTime >= 0 )
        {
            dashTime -= Time.deltaTime;
        }

        if (dashDelay >= 0)
        {
            dashDelay -= Time.deltaTime;
        }

    }

    void Dash()
    {
        if (dashDelay <= 0)
        {
            Vector3 normalizedVelocity = rb.velocity.normalized;

            rb.velocity = normalizedVelocity * maxDashSpeed;

            dashTime = 0.25f; // how long the player cannot move after dashing
            dashDelay = 0.5f; // how long before the player can actually dash.

            // Make the player flash white and become invincible
            StartCoroutine(FlashPlayerAndMakeInvincible());
        }
       
    }

    IEnumerator FlashPlayerAndMakeInvincible()
    {
        float flashDuration = 0.25f; // Adjust the duration of the flash as needed
        float invincibleDuration = 0.25f; // Adjust the duration of invincibility as needed

        // Disable the player's collider (make the player invincible)
        GetComponent<Collider2D>().enabled = false;

        // Flash the player white by toggling its sprite renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;

        for (float timer = 0; timer < invincibleDuration; timer += Time.deltaTime)
        {
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(flashDuration / 2);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashDuration / 2);
        }

        // Re-enable the player's collider after the invincibility period
        yield return new WaitForSeconds(invincibleDuration - (flashDuration / 2));
        GetComponent<Collider2D>().enabled = true;
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
