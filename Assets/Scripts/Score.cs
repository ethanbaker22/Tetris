using System;
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
    public Text levelText;

    private static int _score = 0;
    private static int _finalScore;
    private static int _level = 0;

    // private static FinalScore _final;

    // Update is called once per frame
    private void Update()
    {
        UpdateScore();
        UpdateLevel();
        // SetFinalScore();
    }
    
    /**
     * Sets score to 0 when new game is started
     */
    public static void NewGame()
    {
        _score = 0;
        _level = 0;
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

    /**
     * 
     */
    public void AddToLevel(int level)
    {
        _level = level;
        UpdateLevel();
    }

    /**
     * 
     */
    private void UpdateLevel()
    {
        levelText.text = "Level: " + _level;
    }
}