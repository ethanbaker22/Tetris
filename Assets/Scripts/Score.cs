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
    public Text finalScoreText;

    private static int _score = 0;
    private static int _finalScore;

    // private static FinalScore _final;
    
    // Update is called once per frame
    private void Update()
    {
        UpdateScore();
        // SetFinalScore();
    }
    
    /**
     * Sets score to 0 when new game is started
     */
    public static void NewGame()
    {
        _score = 0;
    }
    
    /**
     * Updates the score variable 
     */
    public void AddToScore(int addScore)
    {
        _score += addScore;
        UpdateScore();
    }

    /**
     * Updates Score Text
     */
    private void UpdateScore()
    {
        scoreText.text = "Score: " + _score;
    }

    /**
     * Sets the final score when called
     */
    public void SetFinalScore()
    {
        finalScoreText.text = "Final Score: " + _score;
    }
}