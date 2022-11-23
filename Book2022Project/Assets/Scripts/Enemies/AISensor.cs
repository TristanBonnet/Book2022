using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    
    [SerializeField]
    float _maxYAngle = 90;

    

    public PlayerLocomotion _player = null;
    public Enemy _enemy = null;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            if (CheckAngle(_player.transform))
            {
                if (_enemy._enemyState != Enemy.EnemyState.SeePlayer)
                {
                    _enemy.SwitchEnemyState(Enemy.EnemyState.SeePlayer);
                }
            }
        }
    }
    private bool CheckAngle(Transform target)
    {
        float angle = Vector3.Angle(transform.forward, target.position - transform.position);

        return angle < _maxYAngle;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        PlayerLocomotion player = other.GetComponentInParent<PlayerLocomotion>();

        if (player != null)
        {
            _player = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerLocomotion player = other.GetComponentInParent<PlayerLocomotion>();

        if (player != null)
        {
            _player = null;
        }
    }
}
