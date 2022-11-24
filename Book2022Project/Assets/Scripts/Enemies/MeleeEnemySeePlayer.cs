using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemySeePlayer : SeePlayer
{
    [SerializeField]
    float _distanceRangeWithPlayer = 0.3f;

    [SerializeField]
    Collider _damageCollider = null;

    [SerializeField]
    private EnemyDamage _enemyDamage = null;

    

    private void FixedUpdate()
    {
        if (_enemy != null && _enemy.AISensor._player)
        {
            _enemy.RotateEnemyToTarget(_enemy.AISensor._player.transform);


            if (_enemy.CheckDistanceWithTarget(_enemy.AISensor._player.transform, _distanceRangeWithPlayer))
            {
                
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
                    
                    _currentDelayBetweenAttacks += Time.deltaTime;
                    
                }

                else
                {

                    _enemyDamage.DoDamage();

                    _currentDelayBetweenAttacks = 0;
                }
            }

        }
        
    }

    
}
