﻿using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Menu.cs
 * @Author Ethan Baker - 986237
 *
 * Deals with which scene to load
 */
public class Menu : MonoBehaviour
{
    public Text highScoreText, secondHighScoreText, thirdHighScoreText, fourthHighScoreText;
    public Button play, tutorial, back;
    public GameObject mainMenu;
    public Animator transition;
    public float transitionTime;

    private Score _score;

    // Start is called before the first frame update
    private void Start()
    {
        _score = FindObjectOfType<Score>();
        highScoreText.text = PlayerPrefs.GetInt("Score1").ToString();
        secondHighScoreText.text = PlayerPrefs.GetInt("Score2").ToString();
        thirdHighScoreText.text = PlayerPrefs.GetInt("Score3").ToString();
        fourthHighScoreText.text = PlayerPrefs.GetInt("Score4").ToString();
    }

    IEnumerator LoadingLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        play.gameObject.SetActive(true);
        tutorial.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }

    // Button is pressed, score is set to 0 and the Tetris scene is loaded.
    public void PlayAgain()
    {
        Score.NewGame();
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Tetris");
    }

    //Open Main Menu Scene
    public void MainMenu()
    {
        StartCoroutine(LoadingLevel());
        mainMenu.SetActive(true);
        play.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    // Open Tutorial Scene
    public void Tutorial()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Tutorial");
    }

    // Open Profile Scene
    public void Profile()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Profile");
    }

    // Open Settings Scene
    public void Settings()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Settings");
    }

    // Open Leaderboard Scene
    public void Leaderboard()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Leaderboard");
    }

    // Exits Game
    public void ExitGame()
    {
        StartCoroutine(LoadingLevel());
        Application.Quit();
    }

    // Return to Main Menu Scene
    public void BackMainMenu()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("MainMenu");
    }

    // Opens Acknowledgements Scene
    public void Acknowledgements()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Acknowledgements");
    }

    // Opens Web Browser to show where the item came from
    public void OpenURL(int urlNum)
    {
        switch (urlNum)
        {
            case 1:
                Application.OpenURL("https://www.youtube.com/watch?v=NmCCQxVBfyM");
                break;
            case 2:
                Application.OpenURL("https://www.youtube.com/watch?v=Xm9O2iJLWxY");
                break;
            case 3:
                Application.OpenURL("https://www.findsounds.com/ISAPI/search.dll?keywords=tetris");
                break;
            case 4:
                Application.OpenURL("http://prattatatat.com/blog-full/2015/1/5/2015-already");
                break;
            case 5:
                Application.OpenURL("https://wallpaperaccess.com/tetris");
                break;
            case 6:
                Application.OpenURL("http://pixelartmaker.com/gallery");
                break;
            case 7:
                Application.OpenURL("https://github.com/ethanbaker22/Tetris");
                break;
        }
    }
}