﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpheight;
    public LayerMask playerMask;
    Transform CharacterTransform, tagGround;
    Rigidbody2D CharacterBody;

    public bool isGrounded = false;



    void Start()
    {
        //Setting rigid body components at start
        CharacterBody = this.GetComponent<Rigidbody2D>();
        CharacterTransform = this.transform;
        //Setting up tag to see if player is on the ground
        tagGround = GameObject.Find(name + "tag_Ground").transform;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Raycast for ground to set if able to jump
        isGrounded = Physics2D.Linecast(CharacterTransform.position, tagGround.position, playerMask);

        //movement and jump Inputs
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
            Jump();      
    }

    public void Move(float horizontalInput)
    {
      //Character movement left and right
      Vector2 movement = CharacterBody.velocity;
      movement.x = horizontalInput * speed;
      CharacterBody.velocity = movement;
    }

    public void Jump()
    {
     //Setting Jump function when player is on the ground
     if(isGrounded)
            CharacterBody.velocity += jumpheight * Vector2.up;
    }

    void OnCollisionEnter2D(Collision2D collision)
    // Setting enemies to be destroyed if player hits them
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Killed");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Spike")
        {
            Debug.Log("You have been spiked");
            //Add Damage when setting up UI
        }

        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Coin Collected");
            Destroy(collision.gameObject);
            //Add Score when setting up UI
        }

        if (collision.gameObject.tag == "Boulder")
        {
            Debug.Log("You Died");
            Destroy(this.gameObject);
            //Player will need to restart, death screen to be created in UI
        }

        if (collision.gameObject.tag == "PLayerEnter")
        {
            Debug.Log("Boulder Trap Active");
            //Destroy(this.gameObject);
        }
    }
    
}
