using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //setting variables for speed, movement and ground detection for enemy character
    public float speed;
    private bool movingRight = true;
    public Transform groundDetection;

    void Update()
    {
        // Setting patrol for the enemy character
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down, 2f);

        if (groundInfo.collider == false)
        {
            //if the enemy is moving right
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                // if the enemy is moving left
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}
