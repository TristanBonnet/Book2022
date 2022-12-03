using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string _levelName = null;

    public void QuitGame()
    {


        Application.Quit();
    }

    public void OpenLevel()
    {

        SceneManager.LoadScene(_levelName);

    }

}
