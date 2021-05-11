using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Profiles.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the Profile system
 */
public class Profiles : MonoBehaviour
{
    public GameObject[] profile;
    public new GameObject[] name;
    public GameObject[] score;
    public int selectedProfile = 0;
    public int selectedName = 0;
    public int selectedScore = 0;

    private string _playerName1, _playerName2, _playerName3, _saveName, _score1, _score2, _score3;
    public Text nameInput, nameOutput1, nameOutput2, nameOutput3, score1, score2, score3;

    private SelectProfile _selectProfile;

    private void Start()
    {
        _selectProfile = FindObjectOfType<SelectProfile>();
    }

    private void Update()
    {
        SwitchName();
    }

    // Switches Name Depending On Which one is selected.
    private void SwitchName()
    {
        switch (selectedName)
        {
            case 0:
                _playerName1 = PlayerPrefs.GetString("name1", "Empty");
                nameOutput1.text = _playerName1;
                PlayerPrefs.SetString("Leaderboardname", _playerName1);
                int playersScore1 = PlayerPrefs.GetInt(_playerName1);
                score1.text = "Highest Score: " + playersScore1;
                break;
            case 1:
                _playerName2 = PlayerPrefs.GetString("name2", "Empty");
                nameOutput2.text = _playerName2;
                PlayerPrefs.SetString("Leaderboardname", _playerName2);
                int playersScore2 = PlayerPrefs.GetInt(_playerName2);
                score1.text = "Highest Score: " + playersScore2;
                break;
            case 2:
                _playerName3 = PlayerPrefs.GetString("name3", "Empty");
                nameOutput3.text = _playerName3;
                PlayerPrefs.SetString("Leaderboardname", _playerName3);
                int playersScore3 = PlayerPrefs.GetInt(_playerName3);
                score1.text = "Highest Score: " + playersScore3;
                break;
        }
    }

    // Changes to Next Profile
    public void NextProfile()
    {
        // Sets current Profile False
        profile[selectedProfile].SetActive(false);
        name[selectedName].SetActive(false);
        score[selectedScore].SetActive(false);

        // Changes Profile through the array
        selectedProfile = (selectedProfile + 1) % profile.Length;
        selectedName = (selectedName + 1) % name.Length;

        // Sets new Profile True
        profile[selectedProfile].SetActive(true);
        name[selectedName].SetActive(true);
        score[selectedScore].SetActive(true);
    }

    // Changes To Previous Profile
    public void PreviousProfile()
    {
        // Sets current Profile False
        profile[selectedProfile].SetActive(false);
        name[selectedName].SetActive(false);
        score[selectedScore].SetActive(false);

        // Changes Profile through the array
        selectedProfile--;
        selectedName--;

        if (selectedProfile < 0)
        {
            selectedProfile += profile.Length;
        }

        if (selectedName < 0)
        {
            selectedName += name.Length;
        }

        // Sets new Profile True
        profile[selectedProfile].SetActive(true);
        name[selectedName].SetActive(true);
        score[selectedScore].SetActive(true);
    }

    // Sets the Profile Name
    public void SetName()
    {
        switch (selectedName)
        {
            case 0:
            {
                PlayerPrefs.SetString("profile", "name1");

                //If not entering name, name stays the same
                if (nameInput.text != "")
                {
                    _saveName = nameInput.text;
                    PlayerPrefs.SetString("name1", _saveName);
                }

                break;
            }
            case 1:
            {
                PlayerPrefs.SetString("profile", "name2");

                //If not entering name, name stays the same
                if (nameInput.text != "")
                {
                    _saveName = nameInput.text;
                    PlayerPrefs.SetString("name2", _saveName);
                }

                break;
            }
            case 2:
            {
                PlayerPrefs.SetString("profile", "name3");

                //If not entering name, name stays the same
                if (nameInput.text != "")
                {
                    _saveName = nameInput.text;
                    PlayerPrefs.SetString("name3", _saveName);
                }

                break;
            }
        }

        PlayerPrefs.SetInt("playerProfile", selectedProfile);
    }
}