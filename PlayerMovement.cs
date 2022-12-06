using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Setting Up Variables 
    public float playerSpeed = 5f;
    private bool isLeft = false;
    private int isDead = 0;
    public GameObject dog;
    public GameObject AudioObject;
    public AudioSource Dead;
    public Rigidbody2D rb;
    public Transform tf;
    Vector2 movement;

    void Start()
    {
        AudioObject = GameObject.Find("PlayerDead");
        Dead = AudioObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (dog.GetComponent<PlayerMain>().playerHealth <= 0)
        {
            playerSpeed = 0f;
            if (isDead == 0)
            {
                isDead = 1;
            }

        }
        if ( isDead == 1)
        {
            Dead.Play();
            isDead = 2;
        }
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);

        if ((movement.x == -1) && (isLeft != true))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
            isLeft = true;
        }

        if ((movement.x == 1) && (isLeft))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
            isLeft = false;
        }
    }
}
