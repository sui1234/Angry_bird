using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBirdController : MonoBehaviour
{

    private bool isPressed = false;
    public float maxDis = 2f;

    private float releaseTime = 0.1f;
    public float smooth = 3.0f;

    public Transform rightPos;
    public Transform leftPos;
    public LineRenderer left;
    public LineRenderer right;


    public GameObject boom;
   

    [HideInInspector]
    public SpringJoint2D sj;
    private Rigidbody2D rb;

    public AudioClip fly;
    public AudioClip click;


    private void Start()
    {
        sj = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // When you hold down the mouse
    private void OnMouseDown()
    {
        AudioPlay(click);
        isPressed = true;
        rb.isKinematic = true;
    }
    //When you release the mouse
    private void OnMouseUp()
    {

        isPressed = false;
        rb.isKinematic = false;
        //sj.enabled = false;
        //bird has no power to fly, so it needs a coroutine to let sj work 0.1f. 
        
        StartCoroutine(Fly());
        StartCoroutine(WaitForNextBird());

        right.enabled = false;
        left.enabled = false;

    }

    private void Update()
    {
        if (isPressed)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if (Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }
            lineSlingShot();

        }

        float cameraPosX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(Mathf.Clamp(cameraPosX,0,15),
            Camera.main.transform.position.y, Camera.main.transform.position.z), smooth * Time.deltaTime);
        
    }

    IEnumerator Fly()
    {
        yield return new WaitForSeconds(releaseTime);
        sj.enabled = false;
        AudioPlay(fly);



    }

    void NextBirdFly()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom,transform.position,Quaternion.identity);
        GameManager._instance.NextBird();
    }

    IEnumerator WaitForNextBird()
    {
        yield return new WaitForSeconds(2f);
        NextBirdFly();
    }

    void lineSlingShot()
    {
        right.enabled = true;
        left.enabled = true;
        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            other.gameObject.SetActive(false);
            ScoreController.scoreValue += 300;
            rb.velocity *= 2;

        }
        if(other.gameObject.CompareTag("Cactus"))
        {
            other.gameObject.SetActive(false);
            rb.velocity *= 0;
        }
    }


    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip,transform.position);
    }



}
