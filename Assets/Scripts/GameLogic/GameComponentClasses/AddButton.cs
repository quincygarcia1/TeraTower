using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AddButton : MonoBehaviour
{
    private Vector3 _rotateDir;
    private Quaternion _rotateAngle;
    [SerializeField] private float _rotationSpeed = 20f;

    [SerializeField] private Transform _newPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.ComponentSelected += Player_OnComponentSelect;
    }

    void Update()
    {
        _rotateDir = (Player.Instance.transform.position - transform.position).normalized;
        _rotateDir.y = 0;
        _rotateAngle = Quaternion.LookRotation(_rotateDir);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotateAngle, Time.deltaTime * _rotationSpeed);
    }

    private void Player_OnComponentSelect(object sender, SelectionArgs e)
    {
        if (e.transform == transform)
        {
            /*
                TODO: When UI menu is created for selected the platform types change this from hard-coded to the
                selection in the UI menu 
            */
            
            float createdY = TotalGarden.Instance.CreateNewPlatform(PlatformType.Standard, DirtType.Standard);
            
            transform.position += 
                new Vector3(0f, createdY * 2, 0f);
        }
    }
}
