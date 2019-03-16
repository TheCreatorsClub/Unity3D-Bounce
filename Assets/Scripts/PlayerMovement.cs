using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speedX = 150f;    // Movement speed along X axis
    private float jumpHeight = 400f;    
    private Rigidbody playerBody;
    private int nJumps;         // Number of times the player has jumped
    private bool grounded;     // Whether the player is on ground

    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        grounded = true;
        nJumps = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;   // Once the player touched the ground
        nJumps = 0;         // Reset the number of jumps
    }

    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        Vector3 moveX = new Vector3(xDir, 0, 0);
        Vector3 moveY = new Vector3(0, yDir, 0);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            playerBody.AddForce(moveX * speedX * Time.deltaTime);      // Move player in direction X with speed speedX for time Time.deltaTime
        }

        if(Input.GetKey(KeyCode.W) && (grounded || (nJumps < 2)) )              // Jump only when on ground or has not jumped more than 2 times in Air
        {
            playerBody.AddForce(jumpHeight * moveY);                   // Move player in Y direction to height jumpHeight
            grounded = false;                                       // As the player is in air
            nJumps++;                                           
        }
    }
}
