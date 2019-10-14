using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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
            enemyDead();
        }
        else if (relativeSpeed < maxSpeed && relativeSpeed > minSpeed)
        {
            spriteRenderer.sprite = hurt;
            
        }
    }

  

    void enemyDead()
    {
        if (isPig == true)
        {
            GameManager._instance.pig.Remove(this);
            ScoreController.scoreValue += 3000;
        }
        else
        {
            if (gameObject.name == "BLOCK_cube")
            {
                GameManager._instance.pig.Remove(this);
                ScoreController.scoreValue += 300;
            }
            else if (gameObject.name == "Block_Long")
            {
                GameManager._instance.pig.Remove(this);
                ScoreController.scoreValue += 100;
            }

        }



        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);

        //show scoreValue of enemy
        GameObject sc = Instantiate(score,transform.position + new Vector3(0,1,0),Quaternion.identity);
        Destroy(sc,1f);

    }

   
}
