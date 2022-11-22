using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
  

    [SerializeField]
    float XRotationSpeed = 1;

    [SerializeField]
    float YRotationSpeed = 1;

    [SerializeField]
    float ZRotationSpeed = 1;

    private void Update()
    {
        Quaternion rotation = new Quaternion(transform.rotation.x + XRotationSpeed * Time.deltaTime, transform.rotation.y + YRotationSpeed * Time.deltaTime, transform.rotation.z + ZRotationSpeed * Time.deltaTime, 0);

        transform.rotation = rotation;
    }
}
