using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ClassicAttack : MonoBehaviour
{

    [SerializeField]
    Collider _weaponCollider = null;
    [SerializeField]
    Animator _animator = null;

    public int _attackNumber = 0;

    [SerializeField]
    UnityEvent _event;

    private float _maxTimeToSetNextAttack = 2;
    private float _currentTimeToSetNextAttack = 0;
    

    public bool _attack = false;
    public bool _incrementAttackNumber = false;
    

    private void Update()
    {
        

        if (_attackNumber > 0)
        {
            if (_attack == false)
            {


                if (_currentTimeToSetNextAttack < _maxTimeToSetNextAttack)
                {
                    _currentTimeToSetNextAttack += Time.deltaTime;
                }

                else
                {
                    _currentTimeToSetNextAttack = 0;
                    _attackNumber = 0;
                }
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    public void StartAttack()
    {
        if (_attack == false)
        {
                     
            SetAttackNumber();
            _animator.SetInteger("AttackNumber", _attackNumber);
            _animator.SetTrigger("TriggerAttack");
        }
      


    }

    public void SetAttack(bool attack)
    {
      _attack = attack;
        
    }

    public void SetAttackNumber()
    {
        
        if (_attackNumber < 3)
        {
            _attackNumber += 1;
        }

        else
        {
            _attackNumber = 0;
        }
    }
}
