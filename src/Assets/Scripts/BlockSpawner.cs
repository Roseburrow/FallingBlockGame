using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public Vector2 spawnScaleMinMax;
    public float spawnAngleMax;

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

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnScaleMinMax.x, spawnScaleMinMax.y);
            Vector2 spawnPosition = new Vector2(
                Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
                screenHalfSizeWorldUnits.y + spawnSize
            );       

            GameObject block = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(0, 0, spawnAngle));
            block.transform.localScale = Vector3.one * spawnSize;
        }
    }
}
