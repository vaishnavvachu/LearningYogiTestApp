using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach this to the ObstaclePrefab

//makes the obstacle move towards the left to hit the player
//when player is hit show GameOver

public class Obstacles : MonoBehaviour
{
    public float speed;                     //Movement Speed
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    //If the obstacle hits player
    //show GAMEOVER
    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Collider.gameObject.SetActive(false);
            gameManager.GameOver();
        }
    }
}
