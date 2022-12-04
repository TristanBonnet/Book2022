using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunEnemy : MonoBehaviour
{
    [SerializeField]
    PlayerState _playerState = null;

    [SerializeField]
    Rigidbody _playerRigibody = null;

    
    private void OnTriggerEnter(Collider other)
    {
        if (_playerState._currentState == PlayerState.GeneralState.InAir && _playerState._currentInAirSubState == PlayerState.InAirSubState.Falling)
        {
            Enemy enemy = other.GetComponentInParent<Enemy>();
            EnemyUp enemyUp = other.GetComponentInParent<EnemyUp>();
            if (enemy != null && enemyUp != null)
            {
                if (enemy.Stun == false)
                {

                    enemy.StunEnemy();
                    AudioSource audio = GetComponentInParent<AudioSource>();
                    PlayerSoundList list = GetComponentInParent<PlayerSoundList>();
                    audio.clip = list._audioList[3];
                    audio.Play();

                    if (_playerRigibody != null)
                    {
                        _playerRigibody.AddForce(Vector3.up * 5000);
                    }
                }
                 

            }
        }
    }
}
