using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    [SerializeField]
    private HealthManager _healthManager = null;


    [SerializeField]
    private int _wrenchNumber = 0;

    [SerializeField]
    private int _maxScrapContainor = 10;
    [SerializeField]
    private int _scrapNumber = 0;
    [SerializeField]
    private int _goldenScrapNumber = 0;
    [SerializeField]
    private int _maxGoldenScrapContainor = 15;

        
    public int _ringNumber = 0;
    private int _currentRingNumberForHealth = 0;

    public int WrenchNumber => _wrenchNumber;
    public int ScrapNumber => _scrapNumber;
    public int RingNumber => _ringNumber;

    public int MaxGoldenScrapContainor => _maxGoldenScrapContainor;

    public int MaxScrapContainor => _maxScrapContainor;

    public int GoldenScrapNumber => _goldenScrapNumber;

    public void AddScrap(int scrapAdded)
    {
        if (_scrapNumber < _maxScrapContainor)
        {
            _scrapNumber += scrapAdded;
        }

        UpdateScrapText();

    }

    public void RemoveScrap(int scrapRemoved)
    {

        _scrapNumber -= scrapRemoved;

        if (_scrapNumber < 0)
        {
            _scrapNumber = 0;
        }

        UpdateScrapText();
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

        GameManager._instance.UIManager.SetLeftUpTriggerOn(true);
    }

    public void RemoveRing(int ringRemoved)
    {

        _ringNumber -= ringRemoved;

        if (_ringNumber < 0)
        {
            _ringNumber = 0;
        }

        GameManager._instance.UIManager.SetLeftUpTriggerOn(true);
    }

    public void AddWrench(int wrenchAdded)
    {
        
            _wrenchNumber += wrenchAdded;


        UpdateWrenchText();
    }

    public void AddGoldenScrap(int goldenScrapAdded)
    {
        
        _goldenScrapNumber += goldenScrapAdded;

        UpdateGoldenScrapText();
    }

    public void RemoveGoldenScrap(int goldenScrapRemoved)
    {
        _goldenScrapNumber -= goldenScrapRemoved;

        if (_goldenScrapNumber < 0)
        {
            _goldenScrapNumber = 0;
        }

        UpdateGoldenScrapText();

    }

    public void AddScrapContainor(int numberToAdd)
    {

        _maxScrapContainor += numberToAdd;
        UpdateMaxScrap();


    }
    public void AddGoldenScrapContainor(int numberToAdd)
    {

        _maxGoldenScrapContainor += numberToAdd;

        UpdateMaxGoldenScrap();
    }




    private void UpdateScrapText()
    {

        GameManager._instance.UIManager.UpdateScrapText();

    }

    private void UpdateGoldenScrapText()
    {

        GameManager._instance.UIManager.UpdateGoldenScrapText();
        

    }

    private void UpdateWrenchText()
    {

        GameManager._instance.UIManager.UpdateWrenchText();

    }

    private void UpdateMaxGoldenScrap()
    {
        GameManager._instance.UIManager.UpdateMaxGoldenScrapText();
        

    }

    private void UpdateMaxScrap()
    {

        GameManager._instance.UIManager.UpdateMaxScrapText();

    }
}
