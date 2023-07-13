using UnityEngine;

public class Coin : MonoBehaviour
{

    public Rigidbody2D rb;
    public CoinSparkle cs;
    public string coinSound;

    public int value;
    float livingTime;

    public PlayerManger player;

    AudioManager sounds;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerManger>();
        sounds = FindObjectOfType<AudioManager>();
        float xVel = Random.Range(-2f, 2f);
        float yVel = Random.Range(-2f, 2f);
        rb.velocity = new Vector2(xVel, yVel);
        livingTime = Random.Range(0.5f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (livingTime > 0)
        {
            livingTime -= Time.deltaTime;
        }
        else
        {
            getCollected();
        }
    }

    void getCollected()
    {
        player.GetCoin(value);
        sounds.Play(coinSound);
        Instantiate(cs, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
