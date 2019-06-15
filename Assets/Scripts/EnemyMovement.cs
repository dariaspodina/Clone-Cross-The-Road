using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speedEnemy = 10;
    public float speedCoef;
    public Vector3 end;


    private void Start()
    {
        speedCoef = 0.5f;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, end, speedEnemy* speedCoef*Time.deltaTime);
    }

    void Update()
    {
        if (transform.position == end)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Move();
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
