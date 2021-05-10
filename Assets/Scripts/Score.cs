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
    private int _fileHighScore, _secondHighScore ,_thirdHighScore, _fourthHighScore;
    private string _nameHighScore, _nameSecondHighScore, _nameThirdHighScore, _nameFourthHighScore, _playerName, _beatHighScore;

    // private static FinalScore _final;

    private void Start()
    {
        _beatHighScore = "";
        // print("Score start player name " + _playerName);
        // _fileHighScore = PlayerPrefs.SetInt("Score1", 0);
        
        _fileHighScore = PlayerPrefs.GetInt("Score1");
        _secondHighScore = PlayerPrefs.GetInt("Score2");
        _thirdHighScore = PlayerPrefs.GetInt("Score3");
        _fourthHighScore = PlayerPrefs.GetInt("Score4");
        
        _nameHighScore = PlayerPrefs.GetString("Score1Name", "#1");
        _nameSecondHighScore = PlayerPrefs.GetString("Score2Name", "#2");
        _nameThirdHighScore = PlayerPrefs.GetString("Score3Name", "#3");
        _nameFourthHighScore = PlayerPrefs.GetString("Score4Name", "#4");
    }

    // Update is called once per frame
    private void Update()
    {
        // print("Score update player name " +  PlayerPrefs.GetString("LeaderboardName"));
        UpdateScore();
        UpdateLevel();
        _fileHighScore = PlayerPrefs.GetInt("Score1");
        _secondHighScore = PlayerPrefs.GetInt("Score2");
        _thirdHighScore = PlayerPrefs.GetInt("Score3");
        _fourthHighScore = PlayerPrefs.GetInt("Score4");

        _nameHighScore = PlayerPrefs.GetString("Score1Name", "#1");
        _nameSecondHighScore = PlayerPrefs.GetString("Score2Name", "#2");
        _nameThirdHighScore = PlayerPrefs.GetString("Score3Name", "#3");
        _nameFourthHighScore = PlayerPrefs.GetString("Score4Name", "#4");
    }
    
    /**
     * Sets score to 0 when new game is started
     */
    public static void NewGame()
    {
        _score = 0;
        _level = 0;
        // _beatHighScore = "";
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
        SetPlayersHighestScore();
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
            _playerName = PlayerPrefs.GetString("Leaderboardname");
            PlayerPrefs.SetString("Score4Name", _nameThirdHighScore);
            PlayerPrefs.SetString("Score3Name", _nameSecondHighScore);
            PlayerPrefs.SetString("Score2Name", _nameHighScore);
            PlayerPrefs.SetString("Score1Name", _playerName);
            // num1.text = _playerName;
            SetEndMsg(1);
            print("here");
        } 
        else if (_score > _secondHighScore)
        {
            PlayerPrefs.SetInt("Score4", _thirdHighScore);
            PlayerPrefs.SetInt("Score3", _secondHighScore);
            PlayerPrefs.SetInt("Score2", _score);
            _playerName = PlayerPrefs.GetString("Leaderboardname");
            PlayerPrefs.SetString("Score4Name", _nameThirdHighScore);
            PlayerPrefs.SetString("Score3Name", _nameSecondHighScore);
            PlayerPrefs.SetString("Score2Name", _playerName);
            // num2.text = _playerName;
            SetEndMsg(2);
            print("here2");
        }
        else if (_score > _thirdHighScore)
        {
            PlayerPrefs.SetInt("Score4", _thirdHighScore);
            PlayerPrefs.SetInt("Score3", _score);
            _playerName = PlayerPrefs.GetString("Leaderboardname");
            PlayerPrefs.SetString("Score4Name", _nameThirdHighScore);
            PlayerPrefs.SetString("Score3Name", _playerName);
            // num3.text = _playerName;
            SetEndMsg(3);
            print("here3");
        }
        else if (_score > _fourthHighScore)
        {
            PlayerPrefs.SetInt("Score4", _score);
            _playerName = PlayerPrefs.GetString("Leaderboardname");
            PlayerPrefs.SetString("Score4Name", _playerName);
            // num4.text = _playerName;
            SetEndMsg(4);
            print("here4");
        }
        else
        {
            SetEndMsg(5);
        }
    }

    private void SetEndMsg(int value)
    {
        switch (value)
        {
            case 4:
                _beatHighScore += "You beat the #4 High Score!";
                beatHighScore.text = _beatHighScore;
                print(beatHighScore);
                break;
            case 3:
                _beatHighScore += "You beat the #3 High Score!";
                beatHighScore.text = _beatHighScore;
                break;
            case 2:
                _beatHighScore += "You beat the #2 High Score!";
                beatHighScore.text = _beatHighScore;
                break;
            case 1:
                _beatHighScore += "You beat the #1 High Score!";
                beatHighScore.text = _beatHighScore;
                break;
            default:
                print("default");
                _beatHighScore = "";
                beatHighScore.text = _beatHighScore;
                break;
        }
    }

    private void SetPlayersHighestScore()
    {
        int playersScore = PlayerPrefs.GetInt(_playerName);
        print("PLAYERS NAME " + _playerName);
        if (playersScore < _score)
        {
            PlayerPrefs.SetInt(_playerName, _score);
            print("Higherscore " + playersScore);
            print("GetHigherScore" + PlayerPrefs.GetInt(_playerName));
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