using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profiles : MonoBehaviour
{
    public GameObject[] profile;
    public new GameObject[] name;
    public int selectedProfile = 0;
    public int selectedName = 0;

    private string _playerName1, _playerName2, _playerName3, _saveName;
    public Text nameInput, nameOutput1, nameOutput2, nameOutput3;

    private SelectProfile _selectProfile;
    private void Update()
    {
        switch (selectedName)
        {
            case 0:
                _playerName1 = PlayerPrefs.GetString("name1", "Default");
                nameOutput1.text = _playerName1;
                break;
            case 1:
                _playerName2 = PlayerPrefs.GetString("name2", "Default");
                nameOutput2.text = _playerName2;
                break;
            case 2:
                _playerName3 = PlayerPrefs.GetString("name3", "Default");
                nameOutput3.text = _playerName3;
                break;
        }
    }

    public void NextProfile()
    {
        profile[selectedProfile].SetActive(false);
        name[selectedName].SetActive(false);
        selectedProfile = (selectedProfile + 1) % profile.Length;
        selectedName = (selectedName + 1) % name.Length;
        profile[selectedProfile].SetActive(true);
        name[selectedName].SetActive(true);
    }

    public void PreviousProfile()
    {
        profile[selectedProfile].SetActive(false);
        name[selectedName].SetActive(false);
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

        profile[selectedProfile].SetActive(true);
        name[selectedName].SetActive(true);
    }


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