using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectProfile : MonoBehaviour
{
    public GameObject[] profile;
    public Text nameText;
    private int _profilePic;

    private string _playerName;
    // Start is called before the first frame update
    void Start()
    {
        _profilePic = PlayerPrefs.GetInt("playerProfile");
        _playerName = PlayerPrefs.GetString("profile");
        nameText.text = PlayerPrefs.GetString(_playerName);

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

    // public void SetProfile(string name)
    // {
    //     playerName = name;
    //     print("access");
    //     
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
