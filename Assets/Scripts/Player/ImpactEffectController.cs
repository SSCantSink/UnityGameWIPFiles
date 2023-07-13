using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffectController : MonoBehaviour
{

    public float livingTime = 1f;

    // Update is called once per frame
    void Update()
    {
        livingTime -= 1f * Time.deltaTime;

        if (livingTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
