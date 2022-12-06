using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float EnemiesEaten;
    public int LevelNumber;
    public float spawnSpeed;
    public GameObject AudioObject;
    public AudioSource AudioPlaying;

    
    // Start is called before the first frame update
    void Start()
    {
        LevelNumber = 1;
        EnemiesEaten = 0.0f;
        spawnSpeed = 2.0f;
        AudioObject = GameObject.Find("LevelComplete");
        AudioPlaying = AudioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesEaten >= 20)
        {
            EnemiesEaten = 0;
            LevelNumber++;
            spawnSpeed = 1.0f;
            AudioPlaying.Play();
        }
        
    }

    public void EnemyEaten()
    {
        EnemiesEaten++;
    }

    public float GetSpawningSpeed()
    {
        return spawnSpeed;
    }

    public int GetGerm1()
    {
        if (LevelNumber == 1)
        {
            return 95;
        }
        else if (LevelNumber == 2)
        {
            return 80;
        }
        else if (LevelNumber == 3)
        {
            return 60;
        }
        return 34;
    }
    public int GetGerm2()
    {
        if (LevelNumber == 1)
        {
            return 95;
        }
        else if (LevelNumber == 2)
        {
            return 95;
        }
        else if (LevelNumber == 3)
        {
            return 75;
        }
        return 66;
    }
    public int GetGerm3()
    {
        if (LevelNumber == 1)
        {
            return 95;
        }
        else if (LevelNumber == 2)
        {
            return 95;
        }
        else if (LevelNumber == 3)
        {
            return 95;
        }
        return 95;
    }

}
