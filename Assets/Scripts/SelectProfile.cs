using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectProfile : MonoBehaviour
{
    public GameObject[] profile;
    public Text nameText, scoreText;
   
    private int _profilePic, _playerScore;
    private string _playerName, _playerNameScore;
    // Start is called before the first frame update
    void Start()
    {
        _profilePic = PlayerPrefs.GetInt("playerProfile");
        _playerName = PlayerPrefs.GetString("profile");
        print(_playerName);
        _playerNameScore = PlayerPrefs.GetString(_playerName);
        _playerScore = PlayerPrefs.GetInt(_playerNameScore);
        PlayerPrefs.SetString("LeaderboardName", _playerName);
        nameText.text = PlayerPrefs.GetString(_playerName);
        scoreText.text = "High Score: " + _playerScore;

        if (_profilePic == 0)
        {
            profile[0].SetActive(true);
        }
        else if (_profilePic == 1)
        {
            profile[1].SetActive(true);
        } 
        else if (_profilePic == 2)
        {
            profile[2].SetActive(true);
        }
        
    }
}