using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int _maxHealthPoint = 4;

    [SerializeField]
    bool _isDead = false;
    [SerializeField]
    UnityEvent _deadEvent = null;

    public int _currentHealthPoint = 0;

    public void AddHealthPoint(int HealthAdded)
    {
        if (_currentHealthPoint < _maxHealthPoint)
        {
            _currentHealthPoint += 1;
        }


    }

    public void RemoveHealthPoint(int HealthRemoved)
    {
        if (_currentHealthPoint > 0)
        {
            _currentHealthPoint -= HealthRemoved;

            if (_currentHealthPoint < 0)
            {
                _currentHealthPoint = 0;
                _isDead = true;
                _deadEvent.Invoke();
            }

            else
            {
                _isDead = false;
            }
        }

        else
        {
            _deadEvent.Invoke();
        }
        



    }

    
}
