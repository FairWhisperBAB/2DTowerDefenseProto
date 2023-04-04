using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;

    [SerializeField] private GameObject gameOverUI;


    private void Start()
    {
        gameIsOver = false;
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
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        Debug.Log("GAME OVER");
        
        Time.timeScale = 0f;

        gameOverUI.SetActive(true);
    }
}
