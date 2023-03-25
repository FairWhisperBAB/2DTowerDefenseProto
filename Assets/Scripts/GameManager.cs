using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
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
        gameEnded = true;
        Debug.Log("GAME OVER");
        //Add an end screen and a menu thingy to get to the main menu or restart the level//
    }
}
