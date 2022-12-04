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

    [SerializeField]
    Rigidbody _playerRigibody = null;

    [SerializeField]
    float _attackForce = 100;

    [SerializeField]
    Animator _enemyMeleeAnimator = null;

    [SerializeField]
    protected private Billboard _billboard = null;
    public enum SeePlayerSubState

    {
        Wait,
        Attack


    }
    

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
                    AttackPlayer();
                    _enemyDamage.DoDamage();
                    _currentDelayBetweenAttacks = 0;
                }
            }

        }
        
    }


    private void AttackPlayer()
    {
        _enemyMeleeAnimator.SetTrigger("Attack");
        

    }

    public void HitByPlayer()
    {

        _enemyMeleeAnimator.SetTrigger("Hit");

    }

}
