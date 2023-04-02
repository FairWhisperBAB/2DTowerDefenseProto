using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + GameStats.Money.ToString();
    }
}
