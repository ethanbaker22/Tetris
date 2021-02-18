using UnityEngine;
using UnityEngine.UI;

/**
 * Score.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the scoring system
 */
public class Score : MonoBehaviour
{
    public Text scoreText;

    private static int _score;
    private static int _finalScore;
    
    // Update is called once per frame
    private void Update()
    {
        UpdateScore();
    }
    
    /**
     * 
     */
    public void NewGame()
    {
        _score = 0;
    }
    
    /**
     * 
     */
    public void AddToScore(int addScore)
    {
        _score += addScore;
        // print(addScore + "  " + _score);
        UpdateScore();
    }

    /**
     * 
     */
    private void UpdateScore()
    {
        // print(_score);
        scoreText.text = "Score: " + _score;
    }

    /**
     * 
     */
    public void GetFinalScore(int final)
    {
        _finalScore = final;
    }
}