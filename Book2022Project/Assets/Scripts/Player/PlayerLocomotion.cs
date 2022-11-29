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
    Transform _startTransformGrounded = null;
    [SerializeField]
    Animator _playerLocomotionAnimator = null;
   



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

    public int _currentJumpNumber = 0;
    private GameObject currentGameObjectFrontOfPlayer = null;
    public float rayCastHeightOffSet = 0.5f;
    public Rigidbody PlayerRigibody => _playerRigibody;
    private float _maxTimeReset = 0.1f;
    private float _currentTimeReset = 0;
    private bool _startDelayResetJump = false;
    private bool _checkGrounded = true;

    private float inAirTimer = 0;

    private float _lastYPosition = 0;
    

    Vector3 _moveDirection;
    private bool SetGroundedAnimTrigger = false;

    //public IEnumerator

    private void Update()
    {
        if (_startDelayResetJump)
        {
            if (_currentTimeReset < _maxTimeReset)
            {
                _currentTimeReset += Time.deltaTime;
            }

            else
            {
                _currentTimeReset = 0;
                _startDelayResetJump = false;
            }
        }
       

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

        if (_wallJump.enabled == false)
        {


            Vector3 movementVelocity = _moveDirection;
            _playerRigibody.velocity = movementVelocity;

            float currentSpeed = movementVelocity.magnitude;
            Debug.Log(currentSpeed);
            _playerLocomotionAnimator.SetFloat("Blend", currentSpeed);
        }

        

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
        Vector3 targetPosition = transform.position;

        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffSet;

        if (_playerState._currentState != PlayerState.GeneralState.Grounded)
        {
            inAirTimer += Time.deltaTime;
            _playerRigibody.AddForce(transform.forward * _leapingVelocity);
            _playerRigibody.AddForce(-Vector3.up * _fallingVelocity * inAirTimer);

            if (_playerState._currentState == PlayerState.GeneralState.InAir)
            {
                if (transform.position.y > _lastYPosition)
                {
                    _playerState._currentInAirSubState = PlayerState.InAirSubState.Jumping;
                }

                else
                {
                    _playerState._currentInAirSubState = PlayerState.InAirSubState.Falling;
                }

                _lastYPosition = transform.position.y;
            }
            

        }
        
        if (Physics.Raycast(_startTransformGrounded.position, Vector3.down, out hit, 1.1f, _layerMask ))
        {
            if (_startDelayResetJump == false)
            {
                inAirTimer = 0;
                _playerState._currentState = PlayerState.GeneralState.Grounded;
                Debug.Log("RESET NUMBER");
                _currentJumpNumber = 0;
                if (SetGroundedAnimTrigger == true)
                {
                    _playerLocomotionAnimator.SetTrigger("Grounded");
                    SetGroundedAnimTrigger = false;
                }
               
            }

            Vector3 rayCastHitPoint = hit.point;
            targetPosition.y = rayCastHitPoint.y;
        }

        else
        {
            _playerState._currentState = PlayerState.GeneralState.InAir;
            
        }

        if (_playerState._currentState == PlayerState.GeneralState.Grounded)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
        }

        else
        {
            transform.position = targetPosition;
        }
    }

    private void WallJump()
    {
        //_playerRigibody.AddForce(Vector3.up * _wallJumpYVelocity);
        //_playerRigibody.AddForce(-transform.forward * _wallJumpZVelocity);*
        _wallJump.enabled = true;
        inAirTimer = 0;
        _playerLocomotionAnimator.SetTrigger("Jump");
        SetGroundedAnimTrigger = true;


    }

    private void Jump()
    {
        
        //_playerRigibody.velocity = Vector3.up * _jumpVelocity;
        _playerJump.enabled = true;
        _currentJumpNumber += 1;
        _playerLocomotionAnimator.SetTrigger("Jump");
        SetGroundedAnimTrigger = true;
        _startDelayResetJump = true;
    }

}
