using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemySeePlayer : SeePlayer
{
    [SerializeField]
    float _distanceRangeWithPlayer = 0.3f;

    [SerializeField]
    Collider _damageCollider = null;



    private void FixedUpdate()
    {
        if (_enemy != null && _enemy.AISensor._player)
        {
            _enemy.RotateEnemyToTarget(_enemy.AISensor._player.transform);


            if (_enemy.CheckDistanceWithTarget(_enemy.AISensor._player.transform, _distanceRangeWithPlayer))
            {
                if (_damageCollider.enabled == false)
                {
                    //_damageCollider.enabled = true;
                }
                _enemy.MoveToTarget();
                

                if (_currentDelayBetweenAttacks != 0)
                {
                    _currentDelayBetweenAttacks = 0;
                }

            }

            else
            {

                _enemy.StopMovement();
                if (_currentDelayBetweenAttacks < _delayBetweenAttacks)
                {
                    if (_damageCollider.enabled)
                    {
                        _damageCollider.enabled = false;
                    }
                    _currentDelayBetweenAttacks += Time.deltaTime;
                    
                }

                else
                {
                    _damageCollider.enabled = true;
                    
                    _currentDelayBetweenAttacks = 0;
                }
            }

        }
        
    }

    
}
