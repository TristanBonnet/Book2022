using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    [SerializeField]
    Transform _playerTransform = null;

    [SerializeField]
    PlayerInput _playerInput = null;

    [SerializeField]
    Transform _camera = null;
   

    // Update is called once per frame
    void Update()
    {
        if (_playerTransform != null)
        {

            transform.position = _playerTransform.position;

        }

        if (_playerInput != null)
        {
            transform.Rotate(_playerInput.JoystickRightYValue * Time.deltaTime * 100, 0, 0);
            transform.Rotate(0, _playerInput.JoystickRightXValue * Time.deltaTime * 100, 0);
            //_camera.transform.RotateAround(transform.position, _camera.transform.right, _playerInput.JoystickRightYValue * Time.deltaTime * 100);
            //_camera.transform.RotateAround(transform.position, _camera.transform.up, -_playerInput.JoystickRightXValue * Time.deltaTime * 100);
            _camera.transform.LookAt(transform);


        }

        //Debug.Log(Vector3.Angle(_camera.transform.forward, _playerTransform.forward));


    }
}
