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
    
    private Score _score;
    public Text highScoreText, secondHighScoreText, thirdHighScoreText ,fourthHighScoreText;
    public Button play, tutorial, back;
    public GameObject mainMenu;

    // Start is called before the first frame update
    private void Start()
    {
        _score = FindObjectOfType<Score>();
        highScoreText.text = PlayerPrefs.GetInt("Score1").ToString();
        secondHighScoreText.text = PlayerPrefs.GetInt("Score2").ToString();
        thirdHighScoreText.text = PlayerPrefs.GetInt("Score3").ToString();
        fourthHighScoreText.text = PlayerPrefs.GetInt("Score4").ToString();
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
        SceneManager.LoadScene("Tetris");
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        play.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void PreGame()
    {
        SceneManager.LoadScene("PreGame");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Profile()
    {
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
        SceneManager.LoadScene("Settings");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
