using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Levels
{
    public bool isBeat = false;
}

public class LevelTracker : MonoBehaviour
{
    [Header("Levels")]
    public Levels Level1 = new Levels();
    public Levels Level2 = new Levels();
    public Levels Level3 = new Levels();
    public Levels Level4 = new Levels();
    public Levels Level5 = new Levels();
    public Levels Level6 = new Levels();
    public Levels Level7 = new Levels();
    public Levels Level8 = new Levels();

    private void Start()
    {
        Level1.isBeat = true;

        Level2.isBeat = false;
        Level3.isBeat = false;
        Level4.isBeat = false;
        Level5.isBeat = false;
        Level6.isBeat = false;
        Level7.isBeat = false;
        Level8.isBeat = false;
    }

}
