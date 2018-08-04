using System.Collections;
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
        tagGround = GameObject.Find(name + "tag_Ground").transform;
        //Setting up tag to see if player is on the ground
         

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
     //Setting Jump function
     if(isGrounded)
            CharacterBody.velocity += jumpheight * Vector2.up;
    }


}
