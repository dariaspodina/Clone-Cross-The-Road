using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnScript : MonoBehaviour
{
    Vector3 startSpawnPosition;
    float randomXValue;
    float speedCoef;
    RoadPool roadPool;

    void Start()
    {
        startSpawnPosition = new Vector3(30, 0.01f, 0);
        speedCoef = 0.5f;
        roadPool = FindObjectOfType<RoadPool>();
    }

    public void SpawnRoad()
    {
        roadPool.ReturnPrefubFromPool(startSpawnPosition, Quaternion.identity, speedCoef);
        startSpawnPosition.x += RandomValueForSpawnRoad();
        speedCoef += 0.1f;
    }

    float RandomValueForSpawnRoad()
    {
        randomXValue = Random.Range(2,8);
        if(randomXValue % 2 == 0)
        {
            return randomXValue;
        }
        else
        {
            randomXValue = 4;
            return randomXValue;
        }
    }
}


