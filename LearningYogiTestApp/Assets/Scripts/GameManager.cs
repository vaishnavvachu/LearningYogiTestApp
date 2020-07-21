using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public GameObject GameOverUI;
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreDisplay;


    private void Start()
    {
        GameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        scoreDisplay.text = "You Survived " + scoreManager.score.ToString()+" viruses";
    }

    public void RestartGame()
    {
        Application.LoadLevel(0);
    }

    public void QuitGame()
    {
        Application.Quit(0);   
    }


}
