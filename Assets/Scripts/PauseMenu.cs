using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject controlPanel;
    private bool toggleControls, togglePause;

    public void PauseFunction()
    {
        togglePause = !togglePause;
        if (togglePause)
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            menuPanel.SetActive(false);
        }
    }

    public void Resume()
    {
        togglePause = false;
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void ControlMenu()
    {
        toggleControls = !toggleControls;
        controlPanel.SetActive(toggleControls);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
