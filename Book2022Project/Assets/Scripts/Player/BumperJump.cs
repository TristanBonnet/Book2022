using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperJump : MonoBehaviour
{
    [SerializeField]
    private float _maxJumpTime = 0.5f;
            
    private Rigidbody _playerRigibody = null;
    [SerializeField]
    Vector3 _vectorForceJump;

    private float _currentJumpTime = 0;

    private void FixedUpdate()
    {
        if (_currentJumpTime < _maxJumpTime)
        {
            _playerRigibody.AddForce(_vectorForceJump);
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

    public void SetPlayerRigibody(Rigidbody rigibody)
    {

        _playerRigibody = rigibody;
        _playerRigibody.velocity = new Vector3(0, 0, 0);

    }
}
