using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    PlayerControls _playerControls;
    [SerializeField]
    PlayerLocomotion _playerLocomotion = null;

    public Vector2 _movementInput;
    public Vector2 _cameraInput;
    public float _verticalInput;
    public float _horizontalInput;

    public float _cameraInputX;
    public float _cameraInputY;

    public bool _jump;


    private float _moveAmount;
    
    private void OnEnable()
    {
        if (_playerControls ==  null)
        {
            _playerControls = new PlayerControls();

            _playerControls.PlayerMovements.Movements.performed += i => _movementInput =  i.ReadValue<Vector2>();
            _playerControls.PlayerMovements.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovements.Jump.performed += i => _jump = true;
            
        }

        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();

    }

    private void HandleMovementInputs()
    {

        _verticalInput = _movementInput.y;
        _horizontalInput = _movementInput.x;

        _cameraInputY = _cameraInput.y;
        _cameraInputX = _cameraInput.x;

    }

    public void HandleAllInputs()
    {

        HandleMovementInputs();
        HandleJumpInput();

    }

    private void HandleJumpInput()
    {
        if (_jump)
        {
            _jump = false;
            _playerLocomotion.Jump();

        }

    }
}
