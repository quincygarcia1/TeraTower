using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidGameObjectType : Exception
{
    public InvalidGameObjectType(){}
    public InvalidGameObjectType(string message) : base(message){}
    public InvalidGameObjectType(string message, Exception innerException) : base(message, innerException){}
    
}
