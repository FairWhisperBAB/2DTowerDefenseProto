using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{

    public static int Money;
    [SerializeField] private int startMoney = 1000;

    public static int Lives;
    [SerializeField] private int startLives = 20;

    public static int waves;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        waves = 0;
    }

}
