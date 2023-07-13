using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public int numOfEnemies;

    public Enemy enemyPF;

    // where will the enemy spawn.
    float xPos;
    float yPos;

    // keeps track of which enemy will spawn.
    int i = 0;

    float timeBetweenSpawns = 0.5f;
    public float maxTimeBwSpanws;

    AudioManager sounds;

    private void Start()
    {
        sounds = FindObjectOfType<AudioManager>();
        sounds.Play("WaveSpawning");
    }

    private void Update()
    {
        if (i < numOfEnemies && timeBetweenSpawns <= 0f)
        {
            xPos = (i % 7) - 3f;
            yPos = -(i / 7) + 3f;
            enemyPF.Spawn(xPos, yPos);
            timeBetweenSpawns = maxTimeBwSpanws;
            i++;
        }
        else
        {
            timeBetweenSpawns -= 1f * Time.deltaTime;
        }

    }


}
