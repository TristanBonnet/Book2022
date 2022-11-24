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
    float _leapingVelocity = 5;
    [SerializeField]
    float _fallingVelocity = 15;
    [SerializeField]
    float _jumpVelocity = 100;
    [SerializeField]
    float _wallJumpZVelocity = 800;
    [SerializeField]
    float _wallJumpYVelocity = 1500;



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
    [SerializeField]
    Collider _collider = null;

    private int _currentJumpNumber = 0;
    private GameObject currentGameObjectFrontOfPlayer = null;
    public float rayCastHeightOffSet = 0.5f;
    public Rigidbody PlayerRigibody => _playerRigibody;

    private float inAirTimer = 0;

    Vector3 _moveDirection;

    private void Update()
    {

       

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, _layerMask))
        {
            currentGameObjectFrontOfPlayer = hit.collider.gameObject;
        }

        else
        {
            if (currentGameObjectFrontOfPlayer != null)
            {
                currentGameObjectFrontOfPlayer = null;
            }
        }

        //Debug.Log(currentGameObjectFrontOfPlayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_collider.bounds.center, _collider.bounds.size * 1.2f);
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
        CheckGrounded();


    }

    public void JumpInput()
    {
        if (_playerState._currentState == PlayerState.GeneralState.Grounded)
        {
            Jump();
        }

        else
        {
            if (currentGameObjectFrontOfPlayer != null)
            {
                WallJump();
            }

            else
            {
                if (_currentJumpNumber < _maxJumpNumber)
                {
                    Jump();
                }
            }
        }
        
        

    }  

    public void ResetJumpNumber()
    {

        _currentJumpNumber = 0;


    }

    public void CheckGrounded()
    {

        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;

        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffSet;

        if (_playerState._currentState != PlayerState.GeneralState.Grounded)
        {
            inAirTimer += Time.deltaTime;
            _playerRigibody.AddForce(transform.forward * _leapingVelocity);
            _playerRigibody.AddForce(-Vector3.up * _fallingVelocity * inAirTimer);
            

        }
        
        if (Physics.Raycast(transform.position, Vector3.down,1.5f, _layerMask ))
        {
            inAirTimer = 0;
            _playerState._currentState = PlayerState.GeneralState.Grounded;
            _currentJumpNumber = 0;
            
        }

        else
        {
            _playerState._currentState = PlayerState.GeneralState.InAir;
            
        }
    }

    private void WallJump()
    {
        _playerRigibody.AddForce(Vector3.up * _wallJumpYVelocity);
        _playerRigibody.AddForce(-Vector3.forward * _wallJumpZVelocity);


    }

    private void Jump()
    {

        _playerRigibody.AddForce(Vector3.up * _jumpVelocity);
    }

}
