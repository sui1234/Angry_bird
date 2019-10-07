using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<RedBirdController> birds;
    public List<PigController> pig;

    public static GameManager _instance;

    private Vector3 originalPos;

    public Text ScoreText;
    private int score;


    private void Awake()
    {
        _instance = this;
        if (birds.Count > 0)
        {
            originalPos = birds[0].transform.position;
        }
        
    }

    private void Start()
    {

        Initialized();
        score = 0;

    }


    private void Initialized()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originalPos;
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


