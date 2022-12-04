using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemySeePlayer : SeePlayer
{
    

    [SerializeField]
    private EnemyProjectileMovement _projectile = null;

    [SerializeField]
    private Transform _projectileStartTransform = null;

    [SerializeField]
    protected private Billboard _billboard = null;

    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    AudioSource _audio = null;
    [SerializeField]
    ParticleSystem _particleSpawn = null;

    private void FixedUpdate()
    {
        if (_enemy != null && _enemy.AISensor._player)
        {
            _enemy.RotateEnemyToTarget(_enemy.AISensor._player.transform);
                               
                                        
                if (_currentDelayBetweenAttacks < _delayBetweenAttacks)
                {

                    _currentDelayBetweenAttacks += Time.deltaTime;

                }

                else
                {


                    Attack();
                    _currentDelayBetweenAttacks = 0;
                }
            

        }

    }

    private void Attack()
    {
        _animator.SetTrigger("Shot");
        _audio.Play();
        ParticleSystem particleSpawn = Instantiate<ParticleSystem>(_particleSpawn);
        particleSpawn.transform.position = transform.position;
        EnemyProjectileMovement projectile =   Instantiate<EnemyProjectileMovement>(_projectile);
        projectile.transform.position = _projectileStartTransform.position;
        projectile.transform.rotation = transform.rotation;




    }

    public void HitByPlayer()
    {

        _animator.SetTrigger("Hit");

    }


}


