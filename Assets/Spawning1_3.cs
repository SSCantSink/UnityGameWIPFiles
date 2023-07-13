using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning1_3 : MonoBehaviour
{

    public Enemy enemyPF;
    public Vector2 place1;
    public Vector2 place2;
    public Vector2 place3;

    AudioManager sounds;

    // Start is called before the first frame update
    void Start()
    {
        sounds = FindObjectOfType<AudioManager>();
        sounds.Play("WaveSpawning");
        enemyPF.Spawn(place1.x, place1.y);
        enemyPF.Spawn(place2.x, place2.y);
        enemyPF.Spawn(place3.x, place3.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
