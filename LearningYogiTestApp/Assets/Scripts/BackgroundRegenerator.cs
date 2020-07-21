using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRegenerator : MonoBehaviour
{

    public float speed;
    public float EndPointXCoordinate;
    public float StartingPointXCoordinate;

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
