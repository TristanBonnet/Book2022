using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    InputPlayer _inputPlayer = null;

    [SerializeField]
    PlayerLocomotion _playerLocomotion = null;

    [SerializeField]
    CameraManager _cameraManager = null;

    [SerializeField]
    LayerMask _layerMask;

    public PlayerLocomotion PlayerLocomotion => _playerLocomotion;

   

    private void Update()
    {
        _inputPlayer.HandleAllInputs();
        TestBoxTrace();
    }

    private void FixedUpdate()
    {
        _playerLocomotion.HandleAllMovements();
        //_playerLocomotion.CheckGrounded();
    }

    private void LateUpdate()
    {
        _cameraManager.HandleAllCameraMovement();
    }

    public void RotateCamera()
    {


    }

    private void TestBoxTrace()
    {
        RaycastHit hit;
        
        if (Physics.BoxCast(transform.position, new Vector3(1,1,1), Vector3.up * -1, out hit, transform.rotation, 2, _layerMask))
        {
            
        }


    }


}
