using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    public bool isSelected = false;

    public Sprite LevelBG;
    private Image image;



    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        if (transform.parent.GetChild(0).name == gameObject.name)
        {
            isSelected = true;
        }
        /*else
        {
            int beforeNum = int.Parse(gameObject.name) - 1;


        }*/


        if (isSelected)
        {
            image.overrideSprite = LevelBG;
            transform.Find("Text").gameObject.SetActive(true);

        }
       
        
    }

   
}
