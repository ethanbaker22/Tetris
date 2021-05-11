using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * SelectProfile.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the Selecting the correct Profile
 */
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

        // Updates Text
        nameText.text = PlayerPrefs.GetString(_playerName);
        scoreText.text = "High Score: " + _playerScore;

        // Switches the Profile
        switch (_profilePic)
        {
            case 0:
                profile[0].SetActive(true);
                break;
            case 1:
                profile[1].SetActive(true);
                break;
            case 2:
                profile[2].SetActive(true);
                break;
        }
    }
}