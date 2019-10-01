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
    // Start is called before the first frame update
    void Start()
    {

        scale = Random.Range(0.01f, 1.5f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        dTime = 0;
        RandomGen();
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0, spriteArray.Length)];
        gameObject.transform.localScale += new Vector3(scale, scale, 0);
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime;
        if (dTime >= 5.0f)
        {
            RandomGen();
            dTime = 0.0f;  
        }


       
    }
    void RandomGen()
    {
       
        rb.velocity = new Vector3(0, 0, 0);
        moveHor = Random.Range(-10.0f, 10.0f);
        moveVer = Random.Range(-10.0f, 10.0f);

        rb.AddForce(new Vector2(moveHor * enemySpeed, moveVer * enemySpeed));
    }


}

