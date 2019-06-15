using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    int score;

    public int Score { get { return score; } }
    
    GameGUI gui;

    void Start()
    {
        score = 0;
        gui = FindObjectOfType<GameGUI>();
    }

    public void IncScore()
    {
        score++;
        gui.ShowGameScore(score);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gui.ChangePauseUnpauseBtn();
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        gui.ChangePauseUnpauseBtn();
    }
}
