using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;

    private static int _score;
    
    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    
    /**
     * 
     */
    public void NewGame()
    {
        _score = 0;
    }
    
    /**
     * 
     */
    public void AddToScore(int addScore)
    {
        _score += addScore;
        print(addScore + "  " + _score);
        UpdateScore();
    }

    /**
     * 
     */
    private void UpdateScore()
    {
        print(_score);
        scoreText.text = "Score: " + _score;
    }
}