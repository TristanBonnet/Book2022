using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapManager : MonoBehaviour
{   
    private int _scrapNumber = 0;

    public void AddScrap(int scrapAdded)
    {
        _scrapNumber += scrapAdded;

    }

    public void RemoveScrap(int scrapRemoved)
    {

        _scrapNumber -= scrapRemoved;

        if (_scrapNumber < 0)
        {
            _scrapNumber = 0;
        }
    }

}
