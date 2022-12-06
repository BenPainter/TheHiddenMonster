using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGerms : MonoBehaviour
{
    //Setting Up Variables 
    public GameObject Germ1;
    public GameObject Germ2;
    public GameObject Germ3;
    public GameObject Pill;
    public GameObject Score;
    public Vector3 origin = new Vector3(1,1,1);

    // Start is called before the first frame update
    void Start()
    {
        // Spawning in new germs 
        InvokeRepeating("Spawn", 2f, 1.5f);
    }


    void Spawn()
    {
        // Picks a random spot on the screen to spawn in a germ
        int germType = Random.Range(1,100);
        int germX = Random.Range(-8,9);
        int germY = Random.Range(-4,5);
        if (germType <= Score.GetComponent<LevelManager>().GetGerm1())
        {
            Instantiate(Germ1, new Vector3(germX,germY,0), Quaternion.identity);
        }
        if (germType > Score.GetComponent<LevelManager>().GetGerm1() && germType <= Score.GetComponent<LevelManager>().GetGerm2())
        {
            Instantiate(Germ2, new Vector3(germX,germY,0), Quaternion.identity);
        }
        if (germType > Score.GetComponent<LevelManager>().GetGerm2() && germType <= Score.GetComponent<LevelManager>().GetGerm3())
        {
            Instantiate(Germ3, new Vector3(germX,germY,0), Quaternion.identity);
        }
        if (germType > Score.GetComponent<LevelManager>().GetGerm3())
        {
            Instantiate(Pill, new Vector3(germX,germY,0), Quaternion.identity);
        }

        
    }
}
