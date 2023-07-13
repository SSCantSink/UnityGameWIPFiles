using UnityEngine;

public class Explosion : MonoBehaviour
{
    float lifeTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0f)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
