using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<RedBirdController> birds;
    public List<EnemyController> pig;

    public static GameManager _instance;

    private Vector3 originalPos;


    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instantiate(Resources.Load<GameObject>("GameManager")).GetComponent<GameManager>();
            }

            return _instance;
        }

    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            if (birds.Count > 0)
            {
                originalPos = birds[0].transform.position;
            }
        }
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
                //lose
            }
        }
        else
        {
            //win
            int i = birds.Count;

            if (i > 0)
            {
                ScoreController.scoreValue += i * 10000;
            }
        }
    }


}


