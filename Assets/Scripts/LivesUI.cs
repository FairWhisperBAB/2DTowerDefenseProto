using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI livesText;
    
    //CAN OPTIMIZE LATER
    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + GameStats.Lives;
    }
}
