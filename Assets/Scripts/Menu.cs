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

    /**
     * 
     */
    public void PlayAgain()
    {
        SceneManager.LoadScene("Tetris");
    }

    /**
     * 
     */
    public void StartGame()
    {
        SceneManager.LoadScene("Tetris");
    }
}
