using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeHandler : MonoBehaviour
{
    public GameObject player;
    Vector3 currentPlayerPos;

    Vector3 startPos;
    Vector3 swipeDelta;

    RoadSpawnScript roadSpawner;
    GameLogic gameLogic;

    int stepsCounter;

    private void Start()
    {
        roadSpawner = FindObjectOfType<RoadSpawnScript>();
        gameLogic = FindObjectOfType<GameLogic>();
    }

    void Update()
    {
        #region MouseClick
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            swipeDelta = Input.mousePosition - startPos;
            if (swipeDelta.magnitude > 10)
            {

                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    if (swipeDelta.x > 0)
                    {
                        currentPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 2f);
                        player.transform.position = currentPlayerPos;
                    }
                    else
                    {
                        currentPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 2f);
                        player.transform.position = currentPlayerPos;
                    }
                }
            }
            else
            {
                stepsCounter++;

                currentPlayerPos = new Vector3(player.transform.position.x + 2f, player.transform.position.y, player.transform.position.z);
                player.transform.position = currentPlayerPos;
                gameLogic.IncScore();
                if (stepsCounter%2 == 0)
                {
                    roadSpawner.SpawnRoad();
                }
            }
        }

#endif
        #endregion

        #region MobileTouch
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startPos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                swipeDelta = (Vector3)Input.touches[0].position - startPos;
                if (swipeDelta.magnitude > 10)
                {
                    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                    {
                        if (swipeDelta.x > 0)
                        {
                            currentPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 2f);
                            player.transform.position = currentPlayerPos;
                        }
                        else
                        {
                            currentPlayerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 2f);
                            player.transform.position = currentPlayerPos;
                        }
                    }
                }
                else
                {
                    stepsCounter++;
                    currentPlayerPos = new Vector3(player.transform.position.x + 2f, player.transform.position.y, player.transform.position.z);
                    player.transform.position = currentPlayerPos;

                    gameLogic.IncScore();
                    if (stepsCounter % 2 == 0)
                    {
                        roadSpawner.SpawnRoad();
                    }
                }
            }
        }
#endif
        #endregion

    }
}


