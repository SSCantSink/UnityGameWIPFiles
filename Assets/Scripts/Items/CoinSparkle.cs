using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSparkle : MonoBehaviour
{

    float livingTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (livingTime > 0)
        {
            livingTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
