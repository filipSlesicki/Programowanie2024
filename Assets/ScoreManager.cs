using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    private int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        Debug.Log("Highscore is " + highScore);
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", score);
        }

    }
}
