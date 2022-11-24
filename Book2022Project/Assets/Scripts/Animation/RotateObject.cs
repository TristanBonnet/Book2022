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
        transform.Rotate(Vector3.up, Time.deltaTime * YRotationSpeed);
        transform.Rotate(Vector3.right, Time.deltaTime * XRotationSpeed);
        transform.Rotate(Vector3.forward, Time.deltaTime * ZRotationSpeed);
    }
}
