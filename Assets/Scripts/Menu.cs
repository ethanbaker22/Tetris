using UnityEditor;
using UnityEngine;
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
    public Text highScoreText;
    public Text secondHighScoreText;
    public Text thirdHighScoreText;
    public Text fourthHighScoreText;

    // Start is called before the first frame update
    private void Start()
    {
        _score = FindObjectOfType<Score>();
        highScoreText.text = PlayerPrefs.GetInt("Score1").ToString();
        secondHighScoreText.text = PlayerPrefs.GetInt("Score2").ToString();
        thirdHighScoreText.text = PlayerPrefs.GetInt("Score3").ToString();
        fourthHighScoreText.text = PlayerPrefs.GetInt("Score4").ToString();
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
