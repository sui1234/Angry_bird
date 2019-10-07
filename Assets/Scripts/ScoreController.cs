using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    public static int scoreValue = 0;
    private void Start()
    {
        scoreText = GetComponent<Text>();

    }
    private void Update()
    {
        scoreText.text = "Score:" + scoreValue;
    }
}


    
