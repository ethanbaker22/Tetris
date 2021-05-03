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
    public Text beatHighScore;

    private static int _score = 0;
    private static int _finalScore;
    private static int _level = 0;
    private int _fileHighScore, _secondHighScore ,_thirdHighScore, _fourthHighScore, _beatHighScore;

    // private static FinalScore _final;

    private void Start()
    {
        // _fileHighScore = PlayerPrefs.SetInt("Score1", 0);
        
        _fileHighScore = PlayerPrefs.GetInt("Score1");
        _secondHighScore = PlayerPrefs.GetInt("Score2");
        _thirdHighScore = PlayerPrefs.GetInt("Score3");
        _fourthHighScore = PlayerPrefs.GetInt("Score4");
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateScore();
        UpdateLevel();
        _fileHighScore = PlayerPrefs.GetInt("Score1");
        _secondHighScore = PlayerPrefs.GetInt("Score2");
        _thirdHighScore = PlayerPrefs.GetInt("Score3");
        _fourthHighScore = PlayerPrefs.GetInt("Score4");
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
        UpdateHighScore();
    }
    
    /**
     * 
     */
    private void UpdateHighScore()
    {
        if (_score > _fileHighScore)
        {
            PlayerPrefs.SetInt("Score4", _thirdHighScore);
            PlayerPrefs.SetInt("Score3", _secondHighScore);
            PlayerPrefs.SetInt("Score2", _fileHighScore);
            PlayerPrefs.SetInt("Score1", _score);
            SetEndMsg(1);
            print("here");
        } 
        else if (_score > _secondHighScore)
        {
            PlayerPrefs.SetInt("Score4", _thirdHighScore);
            PlayerPrefs.SetInt("Score3", _secondHighScore);
            PlayerPrefs.SetInt("Score2", _score);
            SetEndMsg(2);
            print("here2");
        }
        else if (_score > _thirdHighScore)
        {
            PlayerPrefs.SetInt("Score4", _thirdHighScore);
            PlayerPrefs.SetInt("Score3", _score);
            SetEndMsg(3);
            print("here3");
        }
        else if (_score > _fourthHighScore)
        {
            PlayerPrefs.SetInt("Score4", _score);
            SetEndMsg(4);
            print("here4");
        }
    }

    private void SetEndMsg(int value)
    {
        switch (value)
        {
            case 4:
                beatHighScore.text = "You beat the #4 High Score!";
                print(beatHighScore);
                break;
            case 3:
                beatHighScore.text = "You beat the #3 High Score!";
                break;
                print(beatHighScore);
            case 2:
                beatHighScore.text = "You beat the #2 High Score!";
                break;
                print(beatHighScore);
            case 1:
                beatHighScore.text = "You beat the #1 High Score!";
                print(beatHighScore);
                break;
        }
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