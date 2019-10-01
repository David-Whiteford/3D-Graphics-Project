using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float startSpeed;

    private Rigidbody2D rb;
    public GameObject enemyPlanet;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2(moveHor * startSpeed, moveVer * startSpeed));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("EnemyPlanet"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
