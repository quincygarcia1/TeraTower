using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.ComponentSelected += Player_OnComponentSelect;
    }

    private void Player_OnComponentSelect(object sender, SelectionArgs e)
    {
        Debug.Log(e.transform == transform);
    }
}
