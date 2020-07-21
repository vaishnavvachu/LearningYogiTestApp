using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int score;
    public float delayInDestroying;
    public TextMeshProUGUI scoreDisplay;

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
            Debug.Log(score);
            //EndGame
        }
        
    }
}
