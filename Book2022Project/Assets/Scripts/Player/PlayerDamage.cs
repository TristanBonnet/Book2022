using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        Enemy _enemy = other.GetComponentInParent<Enemy>();
        HealthManager _health = GetComponentInParent<HealthManager>();

        if (_enemy != null && _health != null)
        {

            _health.RemoveHealthPoint(1);

        }
    }
}
