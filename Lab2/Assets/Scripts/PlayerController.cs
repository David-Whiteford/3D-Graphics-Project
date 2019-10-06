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
        //set up the initial values
        winText.text = "";
        score = 0;
        scale = 1.0f;
        rb = gameObject.GetComponent<Rigidbody2D>();
        count = 0;
        //function for setting the text
        SetScoreText();
    }

    void FixedUpdate()
    {
        //get input from player to move up and down screen
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        //add the horizontal and vertical movement values to the add force
        rb.AddForce(new Vector2(moveHor * startSpeed, moveVer * startSpeed));
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check the player collides with enemy planet
        if (collision.gameObject.CompareTag("EnemyPlanet"))
        {
            //check if player or enemy planet is biggger
            if (transform.localScale.magnitude >= collision.transform.localScale.magnitude)
            {
                //increment count
                count++;
                //detroy enemy planet if hit
                Destroy(collision.gameObject);
                //scale the player up
                scale += 0.5f;
                //check the size of the enemy
                if (enemyPlanet.transform.localScale.x > scaleObject.transform.localScale.magnitude)
                {
                    //if big + 5
                    score += 5;
                }
                else 
                {
                    //else +2
                    score += 2;
                }
                setScale();
            }
            //if the player is smaller
            else
            {
                //destroy player
                Destroy(gameObject);
                //decrement cout
                count--;
            }
            //set tehe updated score
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        //set the score
        scoreText.text = "Score: " + score.ToString();
        //if all enemy planets are dead
        if(count >= 16)
        {
           //set win text to you win
            winText.text = "YOU WIN ";
        }
        //if you are killed
        if (count == -1)
        {
            //set win text to you loose
            winText.text = "YOU LOOSE ";
        }
    }
    void setScale()
    {
        //set the scale of player
        transform.localScale = new Vector3(scale, scale, 0.0f);
    }
}
