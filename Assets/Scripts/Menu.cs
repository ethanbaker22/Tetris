using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * @Author Ethan Baker - 986237
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
}
