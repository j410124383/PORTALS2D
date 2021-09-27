using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void ToMainScence()
    {
        SceneManager.LoadSceneAsync("LoadScene");
    }

    public void ToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }


    public void QuitGame()
    {
        Application.Quit(); 
    }

}
