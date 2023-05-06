using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnEnableScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveCounterTxt;
    [SerializeField] private GameObject PauseBtn;

    private void OnEnable()
    {
        waveCounterTxt.text = GameStats.waves.ToString();

        PauseBtn.SetActive(false);
    }
}
