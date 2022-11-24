using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectImpulsion : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigibody = null;
    [SerializeField]
    Collider _collider = null;
    [SerializeField]
    float _maxTimeBeforeDelete = 0.5f;
    [SerializeField]
    float _impulsionForce = 10000;
    

    private void Start()
    {

        
        
    }

    private void OnEnable()
    {
        _rigibody.AddForce(Vector3.up * _impulsionForce);
        float ZVelocity = Random.Range(100, 200);
        float XVelocity =  Random.Range(100, 200);
        Vector3 XZVelocity = new Vector3(XVelocity, 0, ZVelocity);
        _rigibody.AddForce(XZVelocity);
    }
}
