using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TotalGarden : MonoBehaviour
{
    public static TotalGarden Instance { get; private set; }
    
    void Awake()
    {
        Instance = this;
    }

    public float CreateNewPlatform(PlatformType platformType, DirtType dirtType)
    {
        var newInstance = 
            Instantiate(PlatformFactory.Instance.GeneratePlatform(
                    platformType, dirtType).transform,
                transform);
        GameObject top = GameObject.FindWithTag("TopPlatform");
        newInstance.transform.position += new Vector3(0f, 
            (top != null) ? top.transform.position.y + 
                            (top.GetComponentsInChildren<BoxCollider>()[0].bounds.size.y) * 2 : 1, 0);
        if (top != null)
        {
            top.tag = "Untagged";
        }
        newInstance.tag = "TopPlatform";
        return newInstance.GetComponentsInChildren<BoxCollider>()[0].bounds.size.y;
    }

    private PlantPlatform GetTop()
    {
        PlantPlatform max = null;
        foreach (var platform in this.GetComponentsInChildren<PlantPlatform>())
        {
            if (max == null || platform.transform.position.y > max.transform.position.y)
            {
                max = platform;
            }
        }
        return max;
        
    }
    
}
