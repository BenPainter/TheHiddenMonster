using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ3Movement : MonoBehaviour
{
    //Setting Up Variables 
    public float playerSpeed = .5f;
    public GameObject score;
    public GameObject dog;
    public GameObject AudioObject;
    public AudioSource Eaten;
    public Rigidbody2D rb;
    public Transform tf;
    Vector2 movement;
    
    void Start()
    {
        dog = GameObject.FindWithTag("Player");
        score = GameObject.Find("LevelManager");
        AudioObject = GameObject.Find("GermDestroyed");
        Eaten = AudioObject.GetComponent<AudioSource>();
        // Based on where the germ starts, it will go for the opposite wall
        if (rb.position.x > 0)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
            movement.x = -Random.Range(1,4);
        }
        else
        {
            movement.x = Random.Range(1,4);
            Debug.Log(movement.x);
        }
        if (rb.position.y > 0)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1,-1,1));
            movement.y = -Random.Range(1,4);
        }
        else
        {
            movement.y = Random.Range(1,4);
        }

        // Cause the germ to move in its pattern
        InvokeRepeating("ZigZag", 1f, 1f);
    }

    void OnCollisionEnter2D(Collision2D  collision)
    {    
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            //Destroy this gameobject if it is hit by the player
            movement.x = 0;
            movement.y = 0;
            Destroy(gameObject);
            score.GetComponent<LevelManager>().EnemyEaten();
            Eaten.Play();
        }

         if (collision.gameObject.tag == "Wall")
        {
            //Destroy this gameobject if it is hit by the player
            movement.x = 0;
            movement.y = 0;
            Destroy(gameObject);
            dog.GetComponent<PlayerMain>().takeDamage(5);
        }
       
    }   
    void ZigZag()
    {
        // Movement pattern for germ3
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1,-1,1));
        movement.y = movement.y * -1;
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }


}
