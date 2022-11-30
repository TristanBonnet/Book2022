using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField]
    HealthManager _playerHealthManager = null;
    [SerializeField]
    RessourceManager _playerRessourcesManager = null;
    [SerializeField]
    PlatformManager _playerPlatformManager = null;
     

    [Header("Texts")]
    [SerializeField]
    TextMeshProUGUI _healthText = null;
    [SerializeField]
    TextMeshProUGUI _scrapText = null;
    [SerializeField]
    TextMeshProUGUI _goldenScrapText = null;
    [SerializeField]
    TextMeshProUGUI _wrenchText = null;
    [SerializeField]
    TextMeshProUGUI _maxScrapContainor = null;
    [SerializeField]
    TextMeshProUGUI _maxGoldenScrapContainor = null;

    [Header("Pictures")]
    [SerializeField]
    Image _constructionPicture = null;
    [SerializeField]
    Image _attackPicture = null;

    private void Start()
    {
        UpdateGoldenScrapText();
        UpdateRingText();
        UpdateScrapText();
        UpdateWrenchText();
        UpdateMaxScrapText();
        UpdateMaxGoldenScrapText();
    }
    public void UpdateScrapText()
    {
        string currentText = _playerRessourcesManager.ScrapNumber.ToString();
        _scrapText.SetText(currentText);


    }

    public void UpdateGoldenScrapText()
    {
        string currentText = _playerRessourcesManager.GoldenScrapNumber.ToString();
        _goldenScrapText.SetText(currentText);


    }

    public void UpdateWrenchText()
    {
        string currentText = _playerRessourcesManager.WrenchNumber.ToString();
        _wrenchText.SetText(currentText);


    }

    public void UpdateRingText()
    {
        string currentText = _playerHealthManager._currentHealthPoint.ToString();
        _healthText.SetText(currentText);


    }

    public void UpdateConstructionPicture(Sprite sprite)
    {

        _constructionPicture.sprite = sprite;


    }

    public void UpdateAttackPicture()
    {

        // Add Attack Picture

    }

    public void UpdateMaxGoldenScrapText()
    {
        string currentText = _playerRessourcesManager.MaxGoldenScrapContainor.ToString();
        _maxGoldenScrapContainor.SetText(currentText);

    }

    public void UpdateMaxScrapText()
    {
        string currentText = _playerRessourcesManager.MaxScrapContainor.ToString();
        _maxScrapContainor.SetText(currentText);

    }
}
