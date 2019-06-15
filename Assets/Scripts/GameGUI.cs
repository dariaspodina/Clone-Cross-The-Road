using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameGUI : MonoBehaviour
{
    Text scoreText;
    Text pauseText;
    Button pauseBtn;
    GameLogic gameLogic;

    public GameObject GameOver;
    GameObject gameOverInstance;

    void Start()
    {
        pauseText = GameObject.Find("PauseBtn").GetComponentInChildren<Text>();
        pauseBtn = GameObject.Find("PauseBtn").GetComponent<Button>();
        scoreText = GameObject.Find("ScoreValue").GetComponent<Text>();
        gameLogic = FindObjectOfType<GameLogic>(); ;
    }

    public void ShowGameScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        try
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void ChangePauseUnpauseBtn()
    {
        if (Time.timeScale == 0)
        {
            pauseText.text = "Unpause";
            pauseBtn.onClick.AddListener(gameLogic.UnPause);
        }
        else
        {
            pauseText.text = "Pause";
            pauseBtn.onClick.AddListener(gameLogic.Pause);
        }
    }

    public void SpawnGameOverCanvas()
    {
        if (gameOverInstance == null)
        {
            Time.timeScale = 0;
            gameOverInstance = Instantiate(GameOver, new Vector3(0, 0, 0), Quaternion.identity);

            Text scoreValue = GameObject.Find("ScoreGameOver").GetComponent<Text>();
            scoreValue.text = gameLogic.Score.ToString();

            Button playBtn = GameObject.Find("PlayButton").GetComponent<Button>();
            playBtn.onClick.AddListener(ReloadScene);
        }
    }
}
