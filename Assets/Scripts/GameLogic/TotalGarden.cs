using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalGarden : MonoBehaviour
{
    public static TotalGarden Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
    }
    
}
