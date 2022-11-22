using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    [SerializeField]
    private int _maxScrapContainor = 10;
    public int _scrapNumber = 0;
        
    public int _ringNumber = 0;


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
        
    }

    public void RemoveRing(int ringRemoved)
    {

        _ringNumber -= ringRemoved;

        if (_ringNumber < 0)
        {
            _ringNumber = 0;
        }
    }
}
