using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject enemy;
    public int amount = 0;
    public bool populateOnStart = true;
    public bool growOverAmount = true;

    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        if (populateOnStart && enemy != null && amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(enemy);
                instance.SetActive(false);
                pool.Add(instance);
            }
        }
    }

    public GameObject ReturnPrefubFromPool(Vector3 position, Quaternion rotation, Vector3 direction, float speed)
    {
        foreach (var item in pool)
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = position;
                item.transform.rotation = rotation;
                item.GetComponent<EnemyMovement>().end = direction;
                item.GetComponent<EnemyMovement>().speedCoef = speed;
                item.SetActive(true);
                return item;
            }
        }

        if (growOverAmount)
        {
            var instance = (GameObject)Instantiate(enemy, position, rotation);
            pool.Add(instance);
            return instance;
        }

        return null;
    }
}
