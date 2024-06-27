using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameInput : MonoBehaviour
{
    // Class to handle all control inputs and Invoke logic based upon those events
    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Camera.Scroll.performed += x => ScrollPerformed(x.ReadValue<float>());
        inputActions.Player.Interact.performed += Click_Performed;
    }

    private void Click_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Player.Instance.IssuePlayerSelection();
    }

    private void ScrollPerformed(float scrollMagnitude)
    {
        Player.Instance.SetYDir(scrollMagnitude);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    
}
