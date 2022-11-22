using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    protected private Enemy _enemy = null;

    [SerializeField]
    protected private float _delayBetweenAttacks;
    protected private float _currentDelayBetweenAttacks;




    private void Start()
    {
        
        _enemy = GetComponentInParent<Enemy>();
    }

    
}
