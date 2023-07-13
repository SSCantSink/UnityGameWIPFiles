using UnityEngine;

public class EnemyEAI : MonoBehaviour
{
    [Header("Dodge Stats")]
    public float maxDodgeDelay;
    float dodgeDelay = 0;
    public float dodgeSpeed;
    public float prolongDashBy; // tells how long should the dash delay be prolonged after a dodge.
    float dodgeXdir;

    [Header("Blink Stats")]
    public float minBlinkSpeed;
    public float maxBlinkSpeed;
    public float minBlinkDelay;
    public float maxBlinkDelay;
    float blinkDelay;

    [Header("Blink/Dodge Trail Stats")]
    public float maxTrailEmitTime;
    float trailEmitTime;

    [Header("Dask to Player Stats")]
    public float minDashDelay;
    public float maxDashDelay;
    public float dashSpeed;
    public float blinkDashTimeReset;
    public float shootDelay = 0;
    float dashDelay;

    [Header("Dash Trail Stats")]
    public float maxATrailEmitTime;
    float aTrailEmitTime;

    // Used to calculate which x/y direction should the next blink be.
    float nextXdir;
    float nextYdir;

    [Header("References")]
    public GameObject shotgunPrefab;
    public GameObject firePoint;
    public Rigidbody2D rb;
    public Collider2D bulletDetector;
    public TrailRenderer trail;
    public TrailRenderer attackTrail;
    Transform player;


    Vector2 nextDodgeDir;
    Vector2 nextBlinkDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bulletDetector = GetComponentInChildren<Collider2D>();
        SetNextDodgeDir();
        dashDelay = Random.Range(minDashDelay, maxDashDelay);
        blinkDelay = Random.Range(minBlinkDelay, maxBlinkDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (dashDelay > 0)
        {
            dashDelay -= Time.deltaTime;
        }
        else
        {
            DashToPlayer();
            dashDelay = Random.Range(minDashDelay, maxDashDelay) + blinkDashTimeReset;
        }

        if (trailEmitTime > 0)
        {
            trailEmitTime -= Time.deltaTime;
        }

        if (trail.emitting && trailEmitTime <= 0)
        {
            trail.emitting = false;
        }

        if (aTrailEmitTime > 0)
        {
            aTrailEmitTime -= Time.deltaTime;
        }

        if (attackTrail.emitting && aTrailEmitTime <= 0)
        {
            attackTrail.emitting = false;
        }

        if (dodgeDelay > 0)
        {
            dodgeDelay -= Time.deltaTime;
        }

        if (blinkDelay > 0)
        {
            blinkDelay -= Time.deltaTime;
        }
        else
        {
            Blink();
            blinkDelay = Random.Range(minBlinkDelay, maxBlinkDelay);
        }

    }

    void DashToPlayer()
    {
        attackTrail.emitting = true;
        aTrailEmitTime = maxATrailEmitTime;
        Invoke("Shoot", shootDelay);
        if (player != null)
            rb.velocity = CalcVecToPlayer() * CalcDashSpeedToPlayer() * dashSpeed;
        blinkDelay = blinkDashTimeReset + Random.Range(minBlinkDelay, maxBlinkDelay);
        dodgeDelay = blinkDashTimeReset + maxDodgeDelay;
    }

    void Shoot()
    {
        Instantiate(shotgunPrefab, firePoint.transform.position, Quaternion.identity);
    }

    float CalcDashSpeedToPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position + new Vector3(0, 1f, 0));
        return distance;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("PlayerBullet"))
        {
            if (dodgeDelay <= 0)
            {
                if (hitInfo.transform.position.x - transform.position.x < 0)
                {
                    dodgeXdir = 1f;
                }
                else
                    dodgeXdir = -1f;
                SetNextDodgeDir();
                Dodge();
                dodgeDelay = maxDodgeDelay;
            }
        }
    }

    Vector2 CalcVecToPlayer()
    {
        Vector2 dir = new Vector2(player.position.x, player.position.y + 1f) - new Vector2(transform.position.x, transform.position.y);
        return dir.normalized;
    }

    void Dodge()
    {
        dashDelay += prolongDashBy;
        Debug.Log("Missed me");
        blinkDelay = Random.Range(minBlinkDelay, maxBlinkDelay);
        trail.emitting = true;
        trailEmitTime = maxTrailEmitTime;
        rb.velocity = nextDodgeDir;
    }

    void SetNextDodgeDir()
    {
        if (transform.position.x > 3)
        {
            nextDodgeDir = new Vector2(dodgeSpeed * -1f, 0f);
        }
        else if (transform.position.x < -3)
        {
            nextDodgeDir = new Vector2(dodgeSpeed * 1f, 0f);
        }
        else
        {
            nextDodgeDir = new Vector2(dodgeSpeed * dodgeXdir, 0f);
        }
    }

    void Blink()
    {
        SetNextBlinkDir();
        trail.emitting = true;
        trailEmitTime = maxTrailEmitTime;
        rb.velocity = nextBlinkDir;
    }

    void SetBlinkXDir()
    {
        if (transform.position.x < -3)
        {
            nextXdir = 1f;
        } else if (transform.position.x > 3)
        {
            nextXdir = -1f;
        }
        else
        {
            int leftOrRight = Random.Range(0, 2);
            if (leftOrRight == 0)
                nextXdir = 1f;
            else
                nextXdir = -1f;
        }
    }

    void SetBlinkYDir()
    {
        if (transform.position.y < 0)
        {
            nextYdir = 1f;
        }
        else if (transform.position.y > 4)
        {
            nextYdir = -1f;
        }
        else
        {
            int leftOrRight = Random.Range(0, 2);
            if (leftOrRight == 0)
                nextYdir = 1f;
            else
                nextYdir = -1f;
        }
    }

    void SetNextBlinkDir()
    {
        SetBlinkXDir();
        SetBlinkYDir();
        float ranXSpeed = Random.Range(minBlinkSpeed, maxBlinkSpeed);
        float ranYSpeed = Random.Range(minBlinkSpeed, maxBlinkSpeed);
        nextBlinkDir = new Vector2(ranXSpeed * nextXdir, ranYSpeed * nextYdir);
    }
}
