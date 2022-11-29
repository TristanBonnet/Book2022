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
                Debug.Log("STUN ENEMY");
                enemy.StunEnemy();

                if (_playerRigibody != null)
                {
                    _playerRigibody.AddForce(Vector3.up * 5000);
                }

            }
        }
    }
}
