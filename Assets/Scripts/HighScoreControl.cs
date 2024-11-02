using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{
    public Text score;
    public Text highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (int.Parse(score.text) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(score.text));
            highScore.text = score.text;
        }
    }
}
