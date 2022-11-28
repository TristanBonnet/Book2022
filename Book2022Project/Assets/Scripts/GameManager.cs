using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField]
    PlayerManager _playerManager = null;

    [SerializeField]
    UIManager _uiManager = null;

    [SerializeField]
    BlueprintManager _blueprintManager = null;

    public PlayerManager PlayerManager => _playerManager;
    public UIManager UIManager => _uiManager;

    public BlueprintManager Blueprint => _blueprintManager;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.Log("More than one GameManager in the scene");
            return;
        }

        _instance = this;
    }

    
}