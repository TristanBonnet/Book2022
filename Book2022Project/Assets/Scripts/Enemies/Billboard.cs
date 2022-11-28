using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera _camera = null;



    private void Start()
    {
        _camera = GameManager._instance.Camera;
    }

    private void Update()
    {
        if (_camera!= null)
        {
            Quaternion rotation = Quaternion.LookRotation(_camera.transform.position - transform.position, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
