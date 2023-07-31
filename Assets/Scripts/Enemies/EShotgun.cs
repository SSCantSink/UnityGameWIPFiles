using UnityEngine;

public class EShotgun : MonoBehaviour
{
    [Header("Stats")]
    public int damage;


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // see if enemy gets hit and make it take damage.
        if (hitInfo.CompareTag("Player"))
        {
            PlayerStats theThing = hitInfo.GetComponent<PlayerStats>();
            theThing.TakeDamage(damage);

        }
    }
}
