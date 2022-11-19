using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigidbody = null;

    [SerializeField]
    float _gravity = -9.8f;

    private void FixedUpdate()
    {

        _rigidbody.AddForce(Vector3.up * _gravity * Time.deltaTime * 1000);

    }


}
