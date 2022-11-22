using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int _maxHealthPoint = 4;

    private int _currentHealthPoint = 0;

    public void AddHealthPoint()
    {
        if (_currentHealthPoint < _maxHealthPoint)
        {
            _currentHealthPoint += 1;
        }


    }
}
