using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveCounterTxt;

    private void OnEnable()
    {
        waveCounterTxt.text = GameStats.waves.ToString();   
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
}
