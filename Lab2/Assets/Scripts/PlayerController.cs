using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float startSpeed;
    private float scale;
    private Rigidbody2D rb;
    public GameObject enemyPlanet;
    void Start()
    {
        scale = 1.0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        rb.AddForce(new Vector2(moveHor * startSpeed, moveVer * startSpeed));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyPlanet"))
        {
            if (transform.localScale.magnitude > collision.transform.localScale.magnitude)
            {
                Destroy(collision.gameObject);
                scale += 0.5f;
                transform.localScale = new Vector3(scale, scale, 0.0f);
            }
            else
            {
                scale -= 0.5f;
                transform.localScale = new Vector3(scale, scale, 0.0f);
            }
        }
    }
}
