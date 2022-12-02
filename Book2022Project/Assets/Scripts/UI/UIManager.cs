using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject _LeftUpUI = null;
    [SerializeField]
    GameObject _bottonUI = null;
    [SerializeField]
    Animator _leftUpAnimator = null;
    [SerializeField]
    Animator _bottomAnimator = null;
    [SerializeField]
    Sprite _emptySlotSprite = null;

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
    [SerializeField]
    Animation _leftUpAnimation = null;
    [SerializeField]
    Animation _bottomAnimation = null;

    [SerializeField]
    float _maxTimeBeforeHideLeftUpUI = 10;

    private float _currentTImeBeforeHideLeftUpUI = 0;

    [SerializeField]
    float _maxTimeBeforeHideBottomUI = 10;

    private float _currentTImeBeforeHideLBottomUI = 0;


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
        SetBottomTriggerOn(false);
    }
    public void UpdateScrapText()
    {
        string currentText = _playerRessourcesManager.ScrapNumber.ToString();
        _scrapText.SetText(currentText);
        SetLeftUpTriggerOn(true);

    }

    public void UpdateGoldenScrapText()
    {
        string currentText = _playerRessourcesManager.GoldenScrapNumber.ToString();
        _goldenScrapText.SetText(currentText);
        SetLeftUpTriggerOn(true);

    }

    public void UpdateWrenchText()
    {
        string currentText = _playerRessourcesManager.WrenchNumber.ToString();
        _wrenchText.SetText(currentText);
        SetLeftUpTriggerOn(true);

    }

    public void UpdateRingText()
    {
        string currentText = _playerHealthManager.CurrentHealthPoint.ToString();
        _healthText.SetText(currentText);
        SetLeftUpTriggerOn(true);

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
        SetLeftUpTriggerOn(true);
    }

    public void UpdateMaxScrapText()
    {
        string currentText = _playerRessourcesManager.MaxScrapContainor.ToString();
        _maxScrapContainor.SetText(currentText);
        SetLeftUpTriggerOn(true);
    }

    public void SetLeftUpTriggerOn(bool set)
    {

        if (set)
        {
            if (_LeftUpUI.activeSelf == false)
            {
                _currentTImeBeforeHideLeftUpUI = 0;
                _leftUpAnimation.Play();
                _LeftUpUI.SetActive(true);
            }
        }

        else
        {
            if (_LeftUpUI.activeSelf)
            {
                _LeftUpUI.SetActive(false);
                
            }
        }

    }

    public void SetBottomTriggerOn(bool set)
    {

        if (set)
        {
            if (_bottonUI.activeSelf == false)
            {
                _currentTImeBeforeHideLBottomUI = 0;
                _bottonUI.SetActive(true);
                _bottomAnimation.Play();
                
            }
        }

        else
        {
            if (_bottonUI.activeSelf)
            {
                _bottonUI.SetActive(false);

            }
        }

    }


    public void ResetAttackSprite()
    {

        _attackPicture.sprite = _emptySlotSprite;

    }

    public void ResetConstructionSprite()
    {

        _constructionPicture.sprite = _emptySlotSprite;

    }


    private void Update()
    {
        if (_LeftUpUI.activeSelf)
        {
            if (_currentTImeBeforeHideLeftUpUI < _maxTimeBeforeHideLeftUpUI)
            {
                _currentTImeBeforeHideLeftUpUI += Time.deltaTime;
            }

            else
            {
                SetLeftUpTriggerOn(false);

            }
        }

        if (_bottonUI.activeSelf)
        {
            if (_currentTImeBeforeHideLBottomUI < _maxTimeBeforeHideBottomUI)
            {
                _currentTImeBeforeHideLBottomUI+= Time.deltaTime;
            }

            else
            {
                SetBottomTriggerOn(false);

            }
        }

    }
}
