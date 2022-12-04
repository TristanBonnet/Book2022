using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private float _maxJumpTime = 0.5f;
    [SerializeField]
    PlayerState _playerState = null;
    [SerializeField]
    private  float _jumpForce = 1000;
    [SerializeField]
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
        AudioSource audio = GetComponentInParent<AudioSource>();
        PlayerSoundList list = GetComponentInParent<PlayerSoundList>();
        audio.clip = list._audioList[0];
        audio.Play();
    }

    
}
