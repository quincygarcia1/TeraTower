using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Class that handles the logic for the player actions and movement computations  
    public static Player Instance { get; private set; }
    public Camera perspectiveCamera { get; private set; }
    private Ray _ray;
    private RaycastHit _hit;
    private int _selectionLayerMask = 1 << LayerConstants.UILayer3D;
    private float _yDir;
    private float _prevMagnitude = 0;
    public event EventHandler<SelectionArgs> ComponentSelected;
    [SerializeField]
    private float _cameraSpeed = 15f;

    private float _scrollCap = 300f;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one player");
            throw new Exception("More than one player");
        }
    
        Instance = this;
        perspectiveCamera = Camera.main;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movement = UpdateScrollPos();
        float cameraDim = 0.7f;
        bool canMove = !Physics.Raycast(transform.position, movement, cameraDim);
        if (canMove)
        {
            transform.position += movement * _cameraSpeed * Time.deltaTime;
        }
    }

    public void IssuePlayerSelection()
    {
        _ray = perspectiveCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 1000f, _selectionLayerMask))
        {
            // Broadcast an Event that something was hit. Check in other objects if they were selected
            ComponentSelected?.Invoke(this, new SelectionArgs(){transform = _hit.transform});
        }
    }
    
    public Vector3 UpdateScrollPos()
    {
        Vector3 dirVec = new Vector3(0f, 0f, 0f);
        dirVec.y = (2 * _yDir)/(10 + Math.Abs(_yDir));

        if (dirVec.y == 0 && Math.Abs(_prevMagnitude) > 0.05)
        {
            dirVec.y = _prevMagnitude * (1 / (float)((Math.Pow(2, Math.Abs(_prevMagnitude)))));
        }

        _prevMagnitude = dirVec.y;
        return dirVec;
    }

    public void SetYDir(float newYDir)
    {
        if (newYDir != 0)
        {
            newYDir = (newYDir > 0) ? Math.Min(newYDir, _scrollCap) : Math.Max(newYDir, -_scrollCap);
        }
        _yDir = newYDir;
    }
}
