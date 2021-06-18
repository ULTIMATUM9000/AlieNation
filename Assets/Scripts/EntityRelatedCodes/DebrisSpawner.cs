using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    public GameObject Debris; //What to Spawn
    float randX; //Where it will Spawn (Random Spawning)
    Vector2 SpawnWhere; //Where the Spawning Takes Place
    public float SpawnRate = 0.5f; //How long it takes till the next arrives
    float NextSpawn = 0.0f; //Goes in Sync with SpawnRate

    private void Update()
    {
        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            randX = Random.Range(91f, 101f); //Declare the Area in which the Spawn will happen || Do match the size with the EmptyObject's x and y
            SpawnWhere = new Vector2(randX, transform.position.y); //Where it will Spawn (Fixed)
            Instantiate(Debris, SpawnWhere, Quaternion.identity); //Spawn Time
        }
    }
    
}
