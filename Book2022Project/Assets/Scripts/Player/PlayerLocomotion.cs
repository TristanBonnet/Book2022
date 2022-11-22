using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField]
    InputPlayer _inputPlayer;
    [SerializeField]
    PlayerState _playerState = null;
    [SerializeField]
    PlayerJump _playerJump = null;
    [SerializeField]
    WallJump _wallJump = null;
    [SerializeField]
    LayerMask _layerMask;
    
    
    [SerializeField]
    Transform _cameraObject;
    [SerializeField]
    Rigidbody _playerRigibody = null;
    [SerializeField]
    float _playerWalkSpeed = 10;
    [SerializeField]
    float _rotationSpeed = 10;
    [SerializeField]
    int _maxJumpNumber = 1;
    [SerializeField]
    float _airControl = 1;

    private int _currentJumpNumber = 0;
    
   
    

    Vector3 _moveDirection;

    private void Update()
    {
       
    }


    private void HandleMovement()
    {

        _moveDirection = _cameraObject.forward * _inputPlayer._verticalInput;
        _moveDirection = _moveDirection + _cameraObject.right * _inputPlayer._horizontalInput;
        _moveDirection.Normalize();
        _moveDirection.y = 0;
        _moveDirection = _moveDirection * _playerWalkSpeed;

        Vector3 movementVelocity = _moveDirection;
        _playerRigibody.velocity = movementVelocity;

    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = _cameraObject.forward * _inputPlayer._verticalInput;
        targetDirection = targetDirection + _cameraObject.right * _inputPlayer._horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection ==  Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }


    public void HandleAllMovements()
    {

        HandleMovement();
        HandleRotation();


    }

    public void Jump()
    {
        
        if (_currentJumpNumber < _maxJumpNumber)
        {
            if (_playerState._currentState == PlayerState.GeneralState.InAir)
            {
                
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, 2, _layerMask))
                {
                    
                    _playerState.ChangeInAirSubState(PlayerState.InAirSubState.Jumping);
                    _wallJump.enabled = true;
                }
            }

            else
            {
                _playerState.ChangeInAirSubState(PlayerState.InAirSubState.Jumping);
                _currentJumpNumber += 1;
                _playerJump.enabled = true;
                Debug.Log("Jump");
            }
            
        }

        else
        {
            if (_playerState._currentState == PlayerState.GeneralState.InAir)
            {
                

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.position + transform.forward, 2, _layerMask))
                {
                    Debug.Log("DoubleJump");
                    _playerState.ChangeInAirSubState(PlayerState.InAirSubState.Jumping);
                    _wallJump.enabled = true;
                }
            }
        }
        

    }  

    public void ResetJumpNumber()
    {

        _currentJumpNumber = 0;


    }
}
