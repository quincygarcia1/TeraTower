using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour
{
    [SerializeField] private Transform standardPlatform;
    public static PlatformFactory Instance;
    
    void Awake()
    {
        Instance = this;
    }
    
    public Transform GeneratePlatform(PlatformType platformType, DirtType dirtType)
    {
        if (platformType == PlatformType.Standard)
        {
            return standardPlatform;
        }

        return null;
    }
}
