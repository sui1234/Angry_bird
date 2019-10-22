using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public GameObject score;
    public bool isForced;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        starDisappear();

        ScoreController.scoreValue += 300;
        GameObject sc = Instantiate(score, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(sc, 1f);
    }

    void starDisappear()
    {
        Destroy(gameObject);
        isForced = true;

    }

   
}
