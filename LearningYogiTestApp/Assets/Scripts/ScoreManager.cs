using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//ScoreManager counts the score via a collider set to it
//When Obstacles hit this score increases
//Destroys them to Improve performance
//store score {USE PLAYER PREFS} and if it is greater than Current HighScore Replace it
public class ScoreManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public int score;
    public float delayInDestroying;                                               //Destroy the obstacle after n seconds on hitting the scoreMnager to improve performance
    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI highScoreDisplayText;
    #endregion

    //Load the HighScore Saved in PLAYERPREFS
    private void Start()
    {
        highScoreDisplayText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    
    //Count the score using collider enter
    //Print score on the textbox
    //Check if the score is greater than highscore
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Obstacle"))
        {
            score++;
            Destroy(collider.gameObject, delayInDestroying);

            scoreDisplayText.text = score.ToString();

            CheckForHighScore(score); 
        }
        
    }

    //if the score is greater than highscore:
    //save new highscore
    //display this score
    private void CheckForHighScore(int Score)
    {
       if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            highScoreDisplayText.text = Score.ToString();
        }
    }
}
