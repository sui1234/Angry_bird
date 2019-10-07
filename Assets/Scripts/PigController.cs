using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float minSpeed = 5f;
    private float relativeSpeed;
    public bool isPig = false;

    private SpriteRenderer spriteRenderer;
    public Sprite hurt;
    public GameObject boom;
    public GameObject score;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        relativeSpeed = collision.relativeVelocity.magnitude;

        if ( relativeSpeed> maxSpeed)
        {
            pigDead();
        }
        else if (relativeSpeed < maxSpeed && relativeSpeed > minSpeed)
        {
            spriteRenderer.sprite = hurt;
            
        }
    }

  

    void pigDead()
    {
        if (isPig == true)
        {
            GameManager._instance.pig.Remove(this);
            ScoreController.scoreValue += 3000;
        }
        if (gameObject.name == "BLOCK_cube")
        {
            GameManager._instance.pig.Remove(this);
            ScoreController.scoreValue += 300;
        }
        else
        {
            GameManager._instance.pig.Remove(this);
            ScoreController.scoreValue += 100;
        }

       
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);

        //show score of pig
        GameObject sc = Instantiate(score,transform.position + new Vector3(0,1,0),Quaternion.identity);
        Destroy(sc,1f);

    }

   
}
