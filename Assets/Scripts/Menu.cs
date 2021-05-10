using System.Collections;
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
    public Text highScoreText, secondHighScoreText, thirdHighScoreText ,fourthHighScoreText;
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

        // SceneManager.LoadScene(levelIndex);
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        play.gameObject.SetActive(true);
        tutorial.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        // play.GetComponent<Text>().enabled = true;
        // tutorial.GetComponent<Text>().enabled = true;
    }

    /**
     * Button is pressed, score is set to 0 and the Tetris scene is loaded
     */
    public void PlayAgain()
    {
        Score.NewGame();
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Tetris");
    }

    public void MainMenu()
    {
        StartCoroutine(LoadingLevel());
        mainMenu.SetActive(true);
        play.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Tutorial()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Tutorial");
    }

    public void Profile()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Profile");
    }

    /**
     * 
     */
    // public void PlayGame()
    // {
    //     SceneManager.LoadScene("Tetris");
    // }

    public void Settings()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Settings");
    }

    public void Leaderboard()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("Leaderboard");
    }

    public void ExitGame()
    {
        StartCoroutine(LoadingLevel());
        Application.Quit();
    }

    public void BackMainMenu()
    {
        StartCoroutine(LoadingLevel());
        SceneManager.LoadScene("MainMenu");
    }
}
