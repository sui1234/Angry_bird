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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void pigDead()
    {
        if (isPig == true)
        {
            GameManager._instance.pig.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);

    }

   
}
