using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public float delayInDestroying;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;

    private void Start()
    {
        highScoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    private void Update()
    {
       scoreDisplay.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            score++;
            Destroy(collider.gameObject, delayInDestroying);

            CheckForHighScore(score); 
        }
        
    }

    private void CheckForHighScore(int Score)
    {
       if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            highScoreDisplay.text = Score.ToString();
        }
    }
}
