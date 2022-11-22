using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    [SerializeField]
    private HealthManager _healthManager = null;


    [SerializeField]
    public int _wrenchNumber = 0;

    [SerializeField]
    private int _maxScrapContainor = 10;
    public int _scrapNumber = 0;
        
    public int _ringNumber = 0;
    private int _currentRingNumberForHealth = 0;


    public void AddScrap(int scrapAdded)
    {
        if (_scrapNumber < _maxScrapContainor)
        {
            _scrapNumber += scrapAdded;
        }
        

    }

    public void RemoveScrap(int scrapRemoved)
    {

        _scrapNumber -= scrapRemoved;

        if (_scrapNumber < 0)
        {
            _scrapNumber = 0;
        }
    }

    public void AddRing(int ringAdded)
    {
        
        _ringNumber += ringAdded;
        _currentRingNumberForHealth += ringAdded;
        if (_currentRingNumberForHealth == 5)
        {
            _healthManager.AddHealthPoint(1);
            _currentRingNumberForHealth = 0;
        }
        
    }

    public void RemoveRing(int ringRemoved)
    {

        _ringNumber -= ringRemoved;

        if (_ringNumber < 0)
        {
            _ringNumber = 0;
        }
    }

    public void AddWrench(int wrenchAdded)
    {
        
            _wrenchNumber += wrenchAdded;
        


    }
}
