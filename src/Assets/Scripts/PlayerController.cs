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
        //Player width is accounted for in Update.
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {   
        float inputX = Input.GetAxis("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        float halfPlayerWidth = transform.localScale.x / 2f;
        if (transform.position.x + halfPlayerWidth < -screenHalfWidthInWorldUnits) 
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }

		if (transform.position.x - halfPlayerWidth > screenHalfWidthInWorldUnits) 
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) {
        if (triggerCollider.tag == "FallingBlock") 
        {
            Destroy(gameObject);
        }
    }
}
