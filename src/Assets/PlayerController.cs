using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;

    float screenHalfWidthInWorldUnits = 9.5f;

    void Start()
    {

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
