using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapAttackProjectile : MonoBehaviour
{
    [SerializeField]
    private float _projectileYForce = 1000;
    [SerializeField]
    private float _projectileZForce = 1000;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    Collider _explosionCollider = null;
    private Rigidbody _rigidbody;


    IEnumerator Destruction()
    {

        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);

    }

    private void Start()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
        Vector3 throwableForce = (transform.forward * _projectileZForce) + (transform.up * _projectileYForce);

        _rigidbody.AddForce(throwableForce);
    }

    private void FixedUpdate()
    {
        if (CheckGrounded())
        {
            ProjectileExplosion();
        }
    }

    private  bool CheckGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.6f, _layerMask ))
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    private void ProjectileExplosion()
    {
        _explosionCollider.enabled = true;
        StartCoroutine(Destruction());


    }
}
