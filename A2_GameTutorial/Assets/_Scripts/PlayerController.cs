using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpheight;
    public LayerMask playerMask;
    Transform CharacterTransform, tagGround;
    Rigidbody2D CharacterBody;
    public int startingHealth = 100;
    public int maxHealth = 100;
    public int damage = 5;
    public int healing = 5;
    public int currentHealth;


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
        if (collision.gameObject.tag == "EnemySafe")
        {
            Debug.Log(" Enemy Killed ");
            Destroy(collision.gameObject);

        }
            if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(" You Died ");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Spike")
        {
            //Add Damage when setting up UI
            currentHealth -= damage;
            //health.text = "Health:" + currentHealth.ToString();
            Debug.Log(" You have been spiked ");
            
        }

        if (collision.gameObject.tag == "Pit")
        {
            //Player will die when landing on Pit Spikes
            Debug.Log(" You Died ");
            Destroy(this.gameObject);
            
        }

        if (collision.gameObject.tag == "Coin")
        {
            //Add Score when setting up UI
            Debug.Log(" Coin Collected ");
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "Health")
        {
            //Add Health when setting up UI
            Debug.Log(" Health Collected ");
            Destroy(collision.gameObject);
            
        }

    }
    
}
