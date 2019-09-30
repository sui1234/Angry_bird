using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<RedBirdController> birds;
    public List<PigController> pig;

    public static GameManager _instance;


    private void Awake()
    {
        _instance = this;
        
    }

    private void Start()
    {
        Initialized();
    }


    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].enabled = true;
                birds[i].sj.enabled = true;
                
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sj.enabled = false;

            }

        }
    }

    public void NextBird()
    {
        if (pig.Count > 0)
        {
            if (birds.Count > 0)
            {
                //next bird flys

                Initialized();
            }
            else
            {
                //lost
            }
        }
        else
        {
            //win
        }
    }

}


