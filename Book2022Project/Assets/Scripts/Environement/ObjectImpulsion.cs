using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectImpulsion : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigibody = null;
    [SerializeField]
    float _maxTimeBeforeDelete = 0.5f;

    private void Start()
    {

        _rigibody.AddForce(Vector3.up * 1000);
    }
}
