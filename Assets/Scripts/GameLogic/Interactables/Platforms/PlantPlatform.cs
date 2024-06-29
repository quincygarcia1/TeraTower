using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPlatform : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public PlantPlatform(DirtType dirtType)
    {
        
    }

    public void OnHover()
    {
        // TODO: have the platform come out perpendicular to the camera viewing vector
        throw new System.NotImplementedException();
    }

    public void OnSelect()
    {
        // TODO: have the platform come out towards the camera vector and call an event to zoom into the platform
        throw new System.NotImplementedException();
    }
}
