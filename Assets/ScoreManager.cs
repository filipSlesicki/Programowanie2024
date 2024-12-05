using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
}
