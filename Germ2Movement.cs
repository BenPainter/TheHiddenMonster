using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ2Movement : MonoBehaviour
{
    //Setting Up Variables 
    public float playerSpeed = .5f;
    public GameObject score;
    public GameObject dog;
    public GameObject AudioObject;
    public AudioSource Eaten;
    public Rigidbody2D rb;
    public Transform tf;
    private int rotationZ = 100;
    Vector2 movement;
    
    void Start()
    {
        dog = GameObject.FindWithTag("Player");
        score = GameObject.Find("LevelManager");
        AudioObject = GameObject.Find("GermDestroyed");
        Eaten = AudioObject.GetComponent<AudioSource>();
        // Based on where the germ starts, it will go for the opposite wall
        int rZ = Random.Range(-1,1);
        if (rZ == 0)
        {
            rZ = 1;
        }
        rotationZ = rotationZ * rZ;
        if (rb.position.x > 0)
        {
            movement.x = -Random.Range(1,4);
        }
        else
        {
            movement.x = Random.Range(1,4);
            Debug.Log(movement.x);
        }
        if (rb.position.y > 0)
        {
            movement.y = -Random.Range(1,4);
        }
        else
        {
            movement.y = Random.Range(1,4);
        }
        InvokeRepeating("Circles", 2f, 1f);
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
    void Circles()
    {
        //Movement
        int randomX = Random.Range(-1,1);
        if (randomX == 0)
        {
            randomX = 1;
        }
        int randomY = Random.Range(-1,1);
        if (randomY == 0)
        {
            randomY = 1;
        }
        movement.y = movement.y * randomX;
        movement.x = movement.x * randomY;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate (0,0,rotationZ*Time.deltaTime);
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }


}
