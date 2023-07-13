using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EShotgunParticle : MonoBehaviour
{
    [Header("Stats")]
    public float lifeTime;
    public float stopEmitTime;

    [Header("References")]
    public ParticleSystem p;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > stopEmitTime)
        {
            lifeTime -= Time.deltaTime;
        }
        else if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            p.enableEmission = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
