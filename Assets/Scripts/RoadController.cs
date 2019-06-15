using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    Vector3 direction;
    Vector3 leftSpawnPoint;
    Vector3 rightSpawnPoint;

    ObjectPool pool;

    int randomValueForSpawnPoint;
    public float speed;

    void Start()
    {
        leftSpawnPoint = gameObject.transform.GetChild(0).position;
        rightSpawnPoint = gameObject.transform.GetChild(1).position;
        pool = FindObjectOfType<ObjectPool>();
        SetRandomDirection();
        InvokeRepeating("SetOnRoad", 0.5f, RandomTimeRepeating());
    }

    void SetOnRoad()
    {
        if (randomValueForSpawnPoint == 0)
        {
            SpawnEnemiesFromPool(leftSpawnPoint, rightSpawnPoint);
        }
        else
        {
            SpawnEnemiesFromPool(rightSpawnPoint, leftSpawnPoint);
        }
    }

    void SetRandomDirection()
    {
        randomValueForSpawnPoint = Random.Range(0, 2);
    }

    void SpawnEnemiesFromPool(Vector3 start,Vector3 end)
    {
        pool.ReturnPrefubFromPool(start, Quaternion.identity, end, speed);
    }

    float RandomTimeRepeating()
    {
        float valueRepeating = Random.Range(2f,3.5f);
        return valueRepeating;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
        CancelInvoke("SetOnRoad");
    }
}
