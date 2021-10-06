using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Move2 : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] float upForce = 200f;
    private bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
            

    }

    // Update is called once per frame
    void Update()
    {

        BirdMove();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        GameController.instance.Die();
        rb.velocity = Vector2.zero;
        GameController.instance.score = 0;
      //  GameController.instance.UpdateAddScore();
        
        

    }

    public void BirdMove()
    {
        if (!isDead)
        {
            if (Time.timeScale != 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {


                   // Time.timeScale = 1;
                    // Everytime the player jump, we are gonna reset the velocity to zero
                    rb.velocity = Vector2.zero;

                    // Add some force
                    rb.AddForce(new Vector2(0, upForce));
                }
            }


        }
    }
}
