using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//GameManager controls whatever happens within the Game
public class GameManager : MonoBehaviour
{
    #region PUBLIC VARIABLES
    public static bool isGameOver = false;
    public GameObject GameOverUI;
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreDisplay;
    public AudioSource audioSource;
    public GameObject tutorialText;
    #endregion

    //Set the GAMEOVERUI false initially
    private void Start()
    {
        StartCoroutine(hideTutorialText());
        GameOverUI.SetActive(false);
    }

    //Show GameOverUI
    //Stop the game running in BG
    //Display the player's score
    //Decrease audio
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
        scoreDisplay.text = "You Survived " + scoreManager.score.ToString()+" viruses";
        audioSource.volume = 0f;

    }

    //Load the scene again to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    //Quit Application
    public void QuitGame()
    {
        Application.Quit(0);   
    }

    IEnumerator hideTutorialText()
    {
        yield return new WaitForSeconds(2);
        tutorialText.SetActive(false);

    }


}
