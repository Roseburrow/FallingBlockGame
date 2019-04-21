using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;

    float screenHalfWidthInWorldUnits;

    void Start()
    {
        //Calculate the screen width in world unity by aspect ratio * orthographic size.
        //Then add the player width / 2 to account for the player.
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits) 
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

		if (transform.position.x > screenHalfWidthInWorldUnits) 
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
}
