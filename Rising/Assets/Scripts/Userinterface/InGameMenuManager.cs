using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool IsPaused { get; private set; }

    //public InputReader inputReader;

    

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

        //inputReader.enabled = false;

    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;

        //inputReader.enabled = true;

    }
}