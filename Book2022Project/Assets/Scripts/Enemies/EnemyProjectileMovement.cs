using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    [SerializeField]
    float _projectileSpeed = 1;
    private Rigidbody _projectileRigibody = null;
    [SerializeField]
    private EnemyDamage _enemyDamage = null;

    IEnumerator DestroyCoroutine()
    {

        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);

    }

    private void Awake()
    {
        _projectileRigibody = GetComponentInParent<Rigidbody>();
        
    }

    private void Start()
    {
        StartCoroutine(DestroyCoroutine());
    }


    private void FixedUpdate()
    {
        if (_enemyDamage.Player != null && _enemyDamage.PlayerHealthManager != null)
        {
            
            Destroy(this.gameObject);
        }
        Vector3 currentVelocity = transform.forward * Time.deltaTime * _projectileSpeed;
        _projectileRigibody.velocity = currentVelocity;
    }


}
