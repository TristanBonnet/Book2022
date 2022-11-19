using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform = null;
    [SerializeField]
    Transform _cameraPivot;
    [SerializeField]
    private Transform _cameraTransform = null;
    [SerializeField]
    LayerMask _collisionLayers;
    private float defaultPosition;

    [SerializeField]
    float _cameraCollisionOffSet = 0.2f;
    [SerializeField]
    float _minimuCollisionOffSet = 0.2f;
    [SerializeField]
    float _cameraCollisionRadius = 2;
    [SerializeField]
    private float cameraFollowSpeed = 0.2f;
    [SerializeField]
    InputPlayer _inputPlayer;
    [SerializeField]
    float _cameraLookSpeed = 2;
    [SerializeField]
    float _cameraPivotSpeed = 2;


    [SerializeField]
    float _lookAngle;
    [SerializeField]
    float _pivotAngle;
    [SerializeField]
    float _minPivotAngle = -35;
    [SerializeField]
    float _maxPivotAngle = 35;

    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 _cameraVectorPosition;

    private void Awake()
    {
        defaultPosition = _cameraTransform.localPosition.z;
    }
    private void Followtarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;
        _lookAngle = _lookAngle + (_inputPlayer._cameraInputX * _cameraLookSpeed);
        _pivotAngle = _pivotAngle - (_inputPlayer._cameraInputY * _cameraPivotSpeed);
        _pivotAngle = Mathf.Clamp(_pivotAngle, _minPivotAngle, _maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = _lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = _pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        _cameraPivot.localRotation = targetRotation;


    }

    public void HandleAllCameraMovement()
    {
        Followtarget();
        RotateCamera();
        HandleCameraCollisions();

    }

    private void HandleCameraCollisions()
    {

        float targetPosition = defaultPosition;
        RaycastHit hit;

        Vector3 direction = _cameraTransform.position - _cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(_cameraPivot.transform.position, _cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), _collisionLayers ))
        {

            float distance = Vector3.Distance(_cameraPivot.position, hit.point);

            targetPosition = targetPosition - (distance - _cameraCollisionOffSet);
        }

        if (Mathf.Abs(targetPosition) < _minimuCollisionOffSet)
        {

            targetPosition = targetPosition - _minimuCollisionOffSet;

        }

        _cameraVectorPosition.z = Mathf.Lerp(_cameraTransform.localPosition.z, targetPosition, 0.2f);
        _cameraTransform.localPosition = _cameraVectorPosition;
    }
}
