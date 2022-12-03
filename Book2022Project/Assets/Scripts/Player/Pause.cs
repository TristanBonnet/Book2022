using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseUI = null;

    [SerializeField]
    private EventSystem _eventSystem = null;

    [SerializeField]
    private GameObject _resumeButtonGameObject = null;
    [SerializeField]
    private string _sceneName;

    private bool _pause = false;

    public bool StatePause => _pause;

    private void Start()
    {
        _eventSystem.firstSelectedGameObject = _resumeButtonGameObject;
    }
    public void SetPause()
    {

        if (_pause == false)
        {
            _pauseUI.SetActive(true);
            
            _pause = true;
            Time.timeScale = 0;


            
        }

        else
        {
            Time.timeScale = 1;
            _pauseUI.SetActive(false);
            _pause = false;
        }

    }

    public void ClickResumeButton()
    {
        SetPause();
    }

    public void ClickRestartButton()
    {
        
        SceneManager.LoadScene(_sceneName);
        Time.timeScale = 1;
    }

    public void ClickQuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuMap");
            
    }

    private void Update()
    {
        Debug.Log(_eventSystem.firstSelectedGameObject);
    }
}
