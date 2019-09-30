using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlanetController : MonoBehaviour
{

    public float enemySpeed;
    private float dTime;
    private Rigidbody2D rb;
    private float moveHor;
    private float moveVer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dTime = 0;
        RandomGen();
    }

    // Update is called once per frame
    void Update()
    {
        dTime += Time.deltaTime;
        if (dTime >= 1.0f)
        {
            RandomGen();
            dTime = 0.0f;  
        }


       
    }
    void RandomGen()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        moveHor = Random.Range(-10.0f, 10.0f);
        moveVer = Random.Range(-10.0f, 10.0f);

        rb.AddForce(new Vector2(moveHor * enemySpeed, moveVer * enemySpeed));
    }


}

