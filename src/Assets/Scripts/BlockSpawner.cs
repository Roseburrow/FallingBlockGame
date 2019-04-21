using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    Vector2 screenHalfSizeWorldUnits;

    public float secondsBetweenSpawn = 1;
    float nextSpawnTime;

    void Start()
    {
        //Get screen width for spawning in valid places.
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            //Gets a random position where x is between the screen width and the y is half the screen width.
            Vector2 spawnPosition = new Vector2(
                Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
                screenHalfSizeWorldUnits.y + 0.5f
            );
            Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
