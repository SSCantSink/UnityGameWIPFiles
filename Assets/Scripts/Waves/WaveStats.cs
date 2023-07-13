using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveStats : MonoBehaviour
{

    // used to find a wave's name.
    public string name;

    // whether the wave was completed or not.
    public bool isComplete = false;

    // Wave Manager changes this so the wave can be deleted.
    //public bool willBeDestroyed = false;

    // Delay for wave to realize that it need to check if all enemies are killed.
    float delay = 2.5f;

    // Update is called once per frame
    void Update()
    {
        if (delay >= 0f)
        {
            delay -= Time.deltaTime;
        }

        if (!isComplete && delay <= 0f && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            Debug.Log("You did it!");
            isComplete = true;
            Destroy(gameObject);
        }

        /*
        if (willBeDestroyed)
        {
            Destroy(gameObject);
        }
        */
    }
}
