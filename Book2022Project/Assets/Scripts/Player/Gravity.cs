using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigidbody = null;

    [SerializeField]
    float _gravity = -9.8f;

    [SerializeField]
    PlayerState _playerState = null;

    [SerializeField]
    Transform _transformSphereTrace = null;

    [SerializeField]
    LayerMask _layerMask;

    [SerializeField]
    PlayerLocomotion _playerLocomotion = null;

    [SerializeField]
    WallJump _wallJump = null;

    [SerializeField]
    PlayerJump _playerJump = null;

    [SerializeField]
    float _gravityAccelerationIncrementor = 0.001f;

    [SerializeField]
    float _maxDistanceCheckGrounded = 0.2f;


    private float _currentGravityAcceleration = 1;


    private void Update()
    {


       
    }
    private void FixedUpdate()
    {

        if (CheckGrounded() == false)
        {
            switch (_playerState._currentInAirSubState)
            {
                case PlayerState.InAirSubState.Jumping:
                    {
                        _rigidbody.AddForce(Vector3.up * _gravity * Time.deltaTime * 2000);

                    }
                    break;
                case PlayerState.InAirSubState.Falling:
                    {
                        
                        _rigidbody.AddForce(Vector3.up * _gravity * Time.deltaTime * 4000);
                        _currentGravityAcceleration += _gravityAccelerationIncrementor;
                    }
                    break;
                case PlayerState.InAirSubState.none:
                    break;
                default:
                    break;
            }
            



        }

        else
        {
            if (_currentGravityAcceleration != 1)
            {
                _currentGravityAcceleration = 1;
            }
        }
    }

    private bool CheckGrounded()
    {
        if (_playerJump.enabled == false && _wallJump.enabled == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(_transformSphereTrace.position, Vector3.up * -1, out hit, _maxDistanceCheckGrounded, _layerMask))
            {
                PlayerLocomotion player = hit.collider.GetComponentInParent<PlayerLocomotion>();

                if (player == null)
                {

                    _playerLocomotion.ResetJumpNumber();
                    _playerState.ChangeGeneralState(PlayerState.GeneralState.Grounded);
                    return true;

                }

                return false;
            }

            else
            {
                return false;
            }
        }

        return false;
        
        

         

               

         


    }

   
}
