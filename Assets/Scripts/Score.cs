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
    public Text linesCleared;
    public Text frenzy;

    private static int _score = 0;
    private static int _finalScore;
    private static int _level = 0;
    private static int _linesCleared = 0;
    private int _fileHighScore, _secondHighScore, _thirdHighScore, _fourthHighScore;

    private string _nameHighScore,
        _nameSecondHighScore,
        _nameThirdHighScore,
        _nameForthHighScore,
        _playerName,
        _beatHighScore,
        _frenzyStatus;
    

    private void Start()
    {
        // Sets Text back to Default
        _beatHighScore = "";
        _frenzyStatus = "No";

        // Gets Current Scores
        _fileHighScore = PlayerPrefs.GetInt("Score1");
        _secondHighScore = PlayerPrefs.GetInt("Score2");
        _thirdHighScore = PlayerPrefs.GetInt("Score3");
        _fourthHighScore = PlayerPrefs.GetInt("Score4");

        // Gets Scores Names
        _nameHighScore = PlayerPrefs.GetString("Score1Name", "N/A");
        _nameSecondHighScore = PlayerPrefs.GetString("Score2Name", "N/A");
        _nameThirdHighScore = PlayerPrefs.GetString("Score3Name", "N/A");
        _nameForthHighScore = PlayerPrefs.GetString("Score4Name", "N/A");
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateScore();
        UpdateLevel();
        UpdateLines();
        UpdateFrenzy();

        // Gets Current Scores
        _fileHighScore = PlayerPrefs.GetInt("Score1");
        _secondHighScore = PlayerPrefs.GetInt("Score2");
        _thirdHighScore = PlayerPrefs.GetInt("Score3");
        _fourthHighScore = PlayerPrefs.GetInt("Score4");

        // Gets Scores Names
        _nameHighScore = PlayerPrefs.GetString("Score1Name", "N/A");
        _nameSecondHighScore = PlayerPrefs.GetString("Score2Name", "N/A");
        _nameThirdHighScore = PlayerPrefs.GetString("Score3Name", "N/A");
        _nameForthHighScore = PlayerPrefs.GetString("Score4Name", "N/A");
    }

    /**
     * Sets score to 0 when new game is started
     */
    public static void NewGame()
    {
        _score = 0;
        _linesCleared = 0;
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
     * Updates the HighScore through PlayerPrefs
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

    /**
     * Sets the message which is shown at the end screen
     */
    private void SetEndMsg(int value)
    {
        switch (value)
        {
            // Beat the 4th Score
            case 4:
                _beatHighScore = "You beat the #4 High Score!";
                beatHighScore.text = _beatHighScore;
                print(beatHighScore);
                print("4");
                break;
            // Beat the 3rd Score
            case 3:
                _beatHighScore = "You beat the #3 High Score!";
                beatHighScore.text = _beatHighScore;
                print("3");
                break;
            // Beat the 2nd Score
            case 2:
                _beatHighScore = "You beat the #2 High Score!";
                beatHighScore.text = _beatHighScore;
                print("2");
                break;
            // Beat the 1st Score
            case 1:
                _beatHighScore = "You beat the #1 High Score!";
                beatHighScore.text = _beatHighScore;
                print("1");
                break;
            // Score does not make Leaderboard
            default:
                print("default");
                _beatHighScore = "";
                beatHighScore.text = _beatHighScore;
                break;
        }
    }

    /**
     * Sets the score of each individual Player
     */
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
     * Adds to which level the player is on
     */
    public void AddToLevel(int level)
    {
        _level = level;
        UpdateLevel();
    }

    /**
     * Updates Level Text
     */
    private void UpdateLevel()
    {
        levelText.text = "Level: " + _level;
    }

    /**
     * Sets the number of lines the player has cleared
     */
    public void SetClearedLines(int numOfLines)
    {
        _linesCleared += numOfLines;
        UpdateLines();
    }

    /**
     * Updates the lines cleared text
     */
    private void UpdateLines()
    {
        linesCleared.text = "Lines: " + _linesCleared;
    }

    /**
     * Updates the Frenzy Text
     */
    private void UpdateFrenzy()
    {
        if (_level == 2 || _level == 5 || _level == 8 || _level == 10)
        {
            _frenzyStatus = "Yes";
            print("FRENZY" + _frenzyStatus);
            frenzy.text = "Frenzy: " + _frenzyStatus;
            frenzy.color = Color.red;
        }
        else
        {
            frenzy.color = Color.white;
            _frenzyStatus = "No";
            print("NOT FRENZY " + _frenzyStatus);
            frenzy.text = "Frenzy: " + _frenzyStatus;
        }
    }
}