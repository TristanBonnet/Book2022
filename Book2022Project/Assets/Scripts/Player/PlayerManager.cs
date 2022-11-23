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

    public PlayerLocomotion PlayerLocomotion => _playerLocomotion;

   

    private void Update()
    {
        _inputPlayer.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        _playerLocomotion.HandleAllMovements();
    }

    private void LateUpdate()
    {
        _cameraManager.HandleAllCameraMovement();
    }

    public void RotateCamera()
    {


    }
}
