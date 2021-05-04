using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPause = false;

    public GameObject pauseMenuUI;
    public new GameObject audio;

    // Update is called once per frame
    void Update()
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
        audio.SetActive(true);
    }

    void Pause()
    {
        audio.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}
