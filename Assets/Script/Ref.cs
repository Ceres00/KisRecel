using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ref : MonoBehaviour
{
    public static Ref Instance;

    public Level2Movement level2Mov;
    public Level2Movement2 level2Mov2;

    private void Awake()
    {
        Instance = this;
    }
}
