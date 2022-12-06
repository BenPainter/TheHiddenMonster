using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{

    //Setting Up Variables 
    public float playerHealth = 100f;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal"); 
    }

    public void takeDamage(int damage)
    {
        playerHealth -= damage;
    }

    public void giveHealth(int health)
    {
        playerHealth += health;

        if (playerHealth > 100f)
        {
            playerHealth = 100f;
        }
    }
}
