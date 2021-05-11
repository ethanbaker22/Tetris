using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * PauseMenu.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the Pause Menu System
 */
public class PauseMenu : MonoBehaviour
{
    public static bool IsPause = false;

    public GameObject pauseMenuUI;
    public new GameObject audio;

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();
    }

    // Checks for when User hits Escape Key
    private void CheckUserInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resumes Game
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
        audio.SetActive(true);
    }

    // Pauses Game
    private void Pause()
    {
        audio.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
    }

    // Loads Main Menu
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Exits Game
    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}