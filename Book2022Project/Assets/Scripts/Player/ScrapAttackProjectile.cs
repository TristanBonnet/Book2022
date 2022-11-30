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
    [SerializeField]
    ParticleSystem _particleSpawn = null;
    [SerializeField]
    float gravityForce = 100f;
    [SerializeField]
    Collider _collider = null;
    [SerializeField]
    float _maxInAirTimer = 2;

    private float inAirTimer = 0;


    IEnumerator Destruction()
    {

        yield return new WaitForSeconds(0.05f);
        ParticleSystem particleSpawn = Instantiate<ParticleSystem>(_particleSpawn);
        particleSpawn.transform.position = transform.position;
        Destroy(this.gameObject);

    }

    IEnumerator SetCollisionEnable()
    {

        yield return new WaitForSeconds(0.2f);
        _collider.enabled = true;

    }

    private void Start()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
        Vector3 throwableForce = (transform.forward * _projectileZForce) + (transform.up * _projectileYForce);

        _rigidbody.AddForce(throwableForce);
        StartCoroutine(SetCollisionEnable());
        

    }

    private void FixedUpdate()
    {
        Debug.Log(inAirTimer);
        if (inAirTimer < _maxInAirTimer)
        {
            inAirTimer += Time.deltaTime;
        }
        
        _rigidbody.AddForce(Vector3.down * inAirTimer * gravityForce);
       
    }

    private void Update()
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
