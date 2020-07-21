using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Regenerate the gameBG so as to make the game feel more immersive

//ADD this script to the BG element

//Need to figure out manually when the BG crosses a limit and needs to regenrate
public class BackgroundRegenerator : MonoBehaviour
{
    #region PUBLIC VARIABLES 
    public float speed;                                                   //speed at which the bg should move
    public float EndPointXCoordinate;                                     //X position where the BG reaches the left end >>for this drag the BG till it goes off from the scene
    public float StartingPointXCoordinate;                                //X position when BG should be regenerated >> Drag the BG to the rightmost end 
    #endregion

    //Regenerate the BG when it croses EndPoint-X
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < EndPointXCoordinate)
        {
            Vector2 pos = new Vector2(StartingPointXCoordinate, transform.position.y);
            transform.position = pos;
        }
    }
}
