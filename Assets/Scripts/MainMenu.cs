using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlPanel;
    private bool toggleControls;

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
