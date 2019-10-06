using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlanetController : MonoBehaviour
{
    public GameObject player;
    public float enemySpeed;
    private float dTime;
    private float scale;
    private Rigidbody2D rb;
    private float moveHor;
    private float moveVer;
    public Sprite[] spriteArray;
    public Sprite largePlanets;
    public GameObject scaleObject;

   
    // Start is called before the first frame update
    void Start()
    {
        
        //sets up the intial values for random scale 
        scale = Random.Range(0.1f, 2.0f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        dTime = 0;
        //random movement function
        RandomGen();
        //set the scale
        gameObject.transform.localScale += new Vector3(scale, scale, 0);
        setTexture();
    }

    // Update is called once per frame
    void Update()
    {
        //timer up to 5
        dTime += Time.deltaTime;
        if (dTime >= 5.0f)
        {
            //call function
            RandomGen();
            dTime = 0.0f;
        }
    }
    void RandomGen()
    {
        //set the velocity of object to 0
        rb.velocity = new Vector3(0, 0, 0);
        //get 2 new values for variables between -10 and 10
        moveHor = Random.Range(-10.0f, 10.0f);
        moveVer = Random.Range(-10.0f, 10.0f);
        //add the new variable to add force and multiply by speed
        rb.AddForce(new Vector2(moveHor * enemySpeed, moveVer * enemySpeed));
    }
    void setTexture()
    {
        //if the scale is over a certain size the set the large objects to red planet
        if (gameObject.transform.localScale.magnitude < scaleObject.transform.localScale.magnitude)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0, spriteArray.Length)];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = largePlanets;
        }
    }

 

}

