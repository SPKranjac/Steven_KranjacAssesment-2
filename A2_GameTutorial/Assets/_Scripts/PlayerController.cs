using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    private float moveInput;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRaduis;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    // Setting character parameters
    public int startingHealth = 100;
    public int maxHealth = 100;
    public int healing = 5;
    public int damage = 5;
    public int currentHealth;
    public int lives;
    public Text healthText;
    public Text coinText;
    public Text livesText;
    private int coins;


    void Start()
    {
        // setting rigid body for player
        rb = GetComponent<Rigidbody2D>();

        // Setting maxium Jumps allowed
        extraJumps = extraJumpsValue;

        // health and lives setup at the begining of the game
        healthText.text = "Health:" + startingHealth.ToString();
        livesText.text = "Lives: " + lives.ToString();

        //Coins set to zero at the start
        coins = 0;
    }

    void FixedUpdate()
    {
        // checking to see if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRaduis, whatIsGround);

        // Setting player movement to Horizontal only
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        // Seeing if the player is on the ground and reseting the max amount of jumps allowed
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        // taking jumps away to allow multi-jump
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpHeight;
            extraJumps--;
        }
        else
            if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpHeight;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    // Setting enemies to be destroyed if player hits them
    {
        if (collision.gameObject.tag == "EnemySafe")
        {
            Debug.Log(" Enemy Killed ");
            Destroy(collision.gameObject);
        }
        // Player killed if hitting wrong part of Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log(" You Died ");
            Destroy(this.gameObject);
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
            coins = coins + 1;
            coinText.text = "Coins: " + coins.ToString();
        }

        if (collision.gameObject.tag == "Health")
        {
            //Add Health when setting up UI
            Debug.Log(" Health Collected ");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Spike")
        {
            // Player takes Damage when spiked
            currentHealth = startingHealth -= damage;
            healthText.text = "Health: " + currentHealth.ToString();
            Debug.Log(" You have been spiked ");
        }
    }
}
