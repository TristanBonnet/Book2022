using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    Rigidbody _playerRigibody = null;
    [SerializeField]
    Transform _playerTransform = null;
    [SerializeField]
    float _rotationSpeed = 1f;
    [SerializeField]
    float _walkSpeed = 1f;
    [SerializeField]
    Transform _cameraTransform = null;
    [SerializeField]
    Transform _cameraTransform90 = null;

    [SerializeField]
    PlayerInput _playerInput = null;



    private void FixedUpdate()
    {



        if (_playerInput != null && _playerRigibody != null)
        {
            if (_playerInput.JoystickLeftYValue != 0)
            {
                if (_playerInput.JoystickLeftYValue > 0)
                {
                    Quaternion localRotation = new Quaternion(_playerTransform.rotation.x, _cameraTransform.rotation.y +  180, _playerTransform.rotation.z, 0);
                    _playerTransform.rotation = localRotation;
                }

                else
                {
                    Debug.Log("ROTATE");
                    Quaternion localRotation = new Quaternion(_playerTransform.rotation.x, _cameraTransform.rotation.y, _playerTransform.rotation.z, 0);
                    _playerTransform.rotation = localRotation;
                }
                
                _playerRigibody.velocity = _playerTransform.forward * _walkSpeed * Time.deltaTime;
            }

            else if (_playerInput.JoystickLeftXValue != 0)
            {
                if (_playerInput.JoystickLeftXValue > 0)
                {
                    Quaternion localRotation = new Quaternion(_playerTransform.rotation.x, _cameraTransform90.rotation.y, _playerTransform.rotation.z, 0);
                    _playerTransform.rotation = localRotation;
                }

                else
                {
                    Quaternion localRotation = new Quaternion(_playerTransform.rotation.x, -_cameraTransform90.rotation.y, _playerTransform.rotation.z, 0);
                    _playerTransform.rotation = localRotation;
                }

                _playerRigibody.velocity = _playerTransform.forward * _walkSpeed * Time.deltaTime;
            }

            else
            {
                _playerRigibody.velocity = _playerTransform.forward * 0;
            }
        }
    }

    private void Update()
    {
        //if (_playerInput != null && _playerTransform != null)
        //{
        //    if (_playerInput.JoystickLeftXValue != 0)
        //    {
        //        _playerTransform.Rotate(0, _rotationSpeed * Time.deltaTime * _playerInput.JoystickLeftXValue, 0);
        //    }
        //}



        
    }
}
