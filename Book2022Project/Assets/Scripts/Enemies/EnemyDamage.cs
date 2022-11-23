using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    int _damageDealed = 1;

    private PlayerManager _player = null;
    private HealthManager _playerHealthManager = null;

    public PlayerManager Player => _player;
    public HealthManager PlayerHealthManager => _playerHealthManager;


    private void Awake()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        HealthManager playerHealthManager = other.GetComponentInParent<HealthManager>();

        if (player != null && playerHealthManager != null)
        {
            _player = player;
            _playerHealthManager = playerHealthManager;
            DoDamage();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerManager player = other.GetComponentInParent<PlayerManager>();
        HealthManager playerHealthManager = other.GetComponentInParent<HealthManager>();

        if (player != null && playerHealthManager != null)
        {
            _player = null;
            _playerHealthManager = playerHealthManager;
        }
    }

    public void DoDamage()
    {

        _playerHealthManager.RemoveHealthPoint(_damageDealed);


    }
}
