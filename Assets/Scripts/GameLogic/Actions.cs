using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions
{
    public static Action<float> ComponentYChange;
    public static Action<bool> OpenUI;
    public static event EventHandler<Instantiate2DArgs> instantiate2DComponent;
    
}
