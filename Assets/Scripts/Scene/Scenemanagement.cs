using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanagement : MonoBehaviour
{
    public void LoadStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void LoadLevelSelection()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void LoadLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void onQuitButton()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
