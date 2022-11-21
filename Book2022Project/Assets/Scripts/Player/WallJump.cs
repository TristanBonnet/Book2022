using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [SerializeField]
    private float _maxJumpTime = 0.5f;
    [SerializeField]
    private float _jumpForce = 1000;
    [SerializeField]
    private Rigidbody _playerRigibody = null;
    [SerializeField]
    float YVelocity = 0;
    [SerializeField]
    float ZVelocity= 0;

    private float _currentJumpTime = 0;

    private void FixedUpdate()
    {
        if (_currentJumpTime < _maxJumpTime)
        {
            _playerRigibody.AddForce(Vector3.up * YVelocity);
            _playerRigibody.AddForce(transform.forward *  ZVelocity);

            _currentJumpTime += Time.deltaTime;

        }

        else
        {
            _currentJumpTime = 0;
            enabled = false;
        }
    }

    private void OnEnable()
    {
        _currentJumpTime = 0;
    }
}
