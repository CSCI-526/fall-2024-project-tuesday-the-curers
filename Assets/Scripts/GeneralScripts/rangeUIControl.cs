using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeUIControl : MonoBehaviour
{
    bool disESC = false;
    public GameObject pauseUI;
    public GameObject loseUI;
    public GameObject winUI;
    public void showLoseUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        disESC = true;
        loseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void showWinUI()
    {
        
        if (winUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            disESC = true;
            winUI.SetActive(false);
            Time.timeScale = 1f;
            disESC = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            disESC = true;
            winUI.SetActive(true);
            Time.timeScale = 0f;
            disESC = false;
        }
    }

    public void showPulseUI()
    {
        
        if (pauseUI.activeSelf)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Start()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        loseUI.SetActive(false);
        winUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !disESC)
        {
            showPulseUI();
        }
    }
}
