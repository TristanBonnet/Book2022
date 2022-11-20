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


    private void Update()
    {


       
    }
    private void FixedUpdate()
    {
        

        
        if (CheckGrounded() == false)
        {
            _rigidbody.AddForce(Vector3.up * _gravity * Time.deltaTime * 2000);
        }

        else
        {
            Debug.Log("Hit Ground");

        }

    }

    private bool CheckGrounded()
    {

        RaycastHit hit;

        
        

         if (Physics.Raycast(_transformSphereTrace.position, Vector3.up * -1, out hit, 0.3f, _layerMask))
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

   
}
