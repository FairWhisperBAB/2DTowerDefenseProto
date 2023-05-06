using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWinCondition", menuName = "WinConditionSO")]
public class WinConditionSO : ScriptableObject
{
    [SerializeField] private int wavesToWin;

    public int WavesToWin => wavesToWin;
}
