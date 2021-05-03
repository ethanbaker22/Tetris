using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Menu.cs
 * @Author Ethan Baker - 986237
 *
 * Deals with which scene to load
 */
public class Menu : MonoBehaviour
{
    
    private Score _score;

    // Start is called before the first frame update
    private void Start()
    {
        _score = FindObjectOfType<Score>();
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

    /**
     * 
     */
    public void StartGame()
    {
        SceneManager.LoadScene("Tetris");
    }
}
