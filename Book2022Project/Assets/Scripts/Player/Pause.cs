using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseUI = null;

    [SerializeField]
    
    
    private string _sceneName;

    private bool _pause = false;

    public bool StatePause => _pause;
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
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneName);
    }

    public void ClickQuitButton()
    {
        Application.Quit();
    }
}
