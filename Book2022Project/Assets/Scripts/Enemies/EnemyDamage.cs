using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    int _damageDealed = 1;

    private void OnTriggerEnter(Collider other)
    {
        
        PlayerManager _player = other.GetComponentInParent<PlayerManager>();
        HealthManager _playerHealthManager = other.GetComponentInParent<HealthManager>();

        if (_player != null && _playerHealthManager != null)
        {
            Debug.Log("RemoveLife");
            _playerHealthManager.RemoveHealthPoint(_damageDealed);
        }
    }
}
