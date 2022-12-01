using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAttack : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _playerRigibody = null;
    [SerializeField]
    private float _spinAttackVelocity;
    [SerializeField]
    private float _maxSpinAttackTime = 1;
    [SerializeField]
    private float _maxDelayBetweenSpinAttack = 0;
    [SerializeField]
    private int _healthRemoved = 1;
    [SerializeField]
    Animator _playerAnimator = null;
    private float _currentDelayBetweenSpinAttack = 0;
    private float _currentSpinAttackTime = 0;
    private bool _spinAttackActivated = false;
    private bool _canSpinAttack = true;
    private bool _startDelay = false;

    public bool SpinAttackActivated => _spinAttackActivated;
    private void FixedUpdate()
    {

        if (_playerRigibody != null && _spinAttackActivated)
        {
            if (_currentSpinAttackTime < _maxSpinAttackTime)
            {
                _currentSpinAttackTime += Time.deltaTime;
                _playerRigibody.AddForce(_spinAttackVelocity * Time.deltaTime * transform.forward);
            }

            else
            {
                _currentSpinAttackTime = 0;
                _spinAttackActivated = false;
                _playerAnimator.SetTrigger("StopSpinAttack");
                _startDelay = true;
            }

        }

        if (_startDelay)
        {
            if (_currentDelayBetweenSpinAttack < _maxDelayBetweenSpinAttack)
            {
                _currentDelayBetweenSpinAttack += Time.deltaTime;
            }

            else
            {
                _startDelay = false;
                _canSpinAttack = true;
                _currentDelayBetweenSpinAttack = 0;
            }
        }
    }

    public void SetSpinAttackActivated(bool set)
    {
        if (_canSpinAttack)
        {
            _spinAttackActivated = set;
            Debug.Log("ACTIVE ANIMATION");
            _playerAnimator.SetTrigger("StartSpinAttack");
            _canSpinAttack = false;
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();
        HealthManager healthManager = other.GetComponentInParent<HealthManager>();

        if (enemy != null && healthManager != null)
        {
            healthManager.RemoveHealthPoint(_healthRemoved, this.gameObject);
        }
    }
}
