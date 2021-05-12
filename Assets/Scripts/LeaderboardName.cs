using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * LeaderboardName.cs
 * @author Ethan Baker - 986237
 *
 * Deals with the leaderboard system
 */
public class LeaderboardName : MonoBehaviour
{
    public Text num1, num2, num3, num4;

    // private string one, two, three, four;

    // Start is called before the first frame update
    void Start()
    {
        print(num1.text + " " + num2.text + " " + num3.text + " " + num4.text);
        num1.text = PlayerPrefs.GetString("Score1Name");
        num2.text = PlayerPrefs.GetString("Score2Name");
        num3.text = PlayerPrefs.GetString("Score3Name");
        num4.text = PlayerPrefs.GetString("Score4Name");
        print(num1.text + " " + num2.text + " " + num3.text + " " + num4.text);
    }
}