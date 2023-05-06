using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    [SerializeField] private GameObject gameOverUI;

    public static bool gameIsWon;
    [SerializeField] private GameObject winUI;
    [SerializeField] private WinConditionSO WinCondition;

    private void Start()
    {
        gameIsOver = false;
        gameIsWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        if (GameStats.Lives <= 0)
        {
            GameOver();
        }

        if (gameIsWon)
        {
            return;
        }
        if (GameStats.waves == WinCondition.WavesToWin)
        {
            GameisWon();
            
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        Debug.Log("GAME OVER");
        
        Time.timeScale = 0f;

        gameOverUI.SetActive(true);
    }

    void GameisWon()
    {
        gameIsWon = true;
        Time.timeScale = 0f;

        winUI.SetActive(true);
    }
}
