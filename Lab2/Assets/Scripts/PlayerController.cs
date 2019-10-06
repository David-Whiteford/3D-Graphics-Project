using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    private int score;
    public float startSpeed;
    private float scale;
    private Rigidbody2D rb;
    public GameObject enemyPlanet;
    public GameObject scaleObject;
   
    int count;
    void Start()
    {
        winText.text = "";
        score = 0;
        scale = 1.0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        count = 0;
        SetScoreText();
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
            if (transform.localScale.magnitude >= collision.transform.localScale.magnitude)
            {
                count++;
                Destroy(collision.gameObject);
                scale += 0.5f;
                if (enemyPlanet.transform.localScale.x > scaleObject.transform.localScale.magnitude)
                {
                    score += 5;
                }
                else 
                {
                    score += 2;
                }
                setScale();
            }
            else
            {
                if (enemyPlanet.transform.localScale.x > scaleObject.transform.localScale.magnitude)
                {
                    score -= 5;
                }
                else
                {
                    score -= 2;
                }
                scale -= 0.5f;
                setScale();
            }
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if(count >= 16)
        {
           
            winText.text = "YOU WIN ";
        }
    }
    void setScale()
    {
        transform.localScale = new Vector3(scale, scale, 0.0f);
    }
}
