using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    float jumpHeight = 3.5f;
    float dirX;
    float moveSpeed = 10f;
    float boundary;

    Vector2 initPos;

    public bool isPC = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boundary = GameController.i.GetMaxWidth();
        initPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case Constants.PLATFORM:
                if (rb.velocity.y > 0)
                    return;
               
                    //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    float force = Mathf.Sqrt(-2 * Physics2D.gravity.y * jumpHeight);
                    rb.velocity = new Vector2(rb.velocity.x, force);
                    AudioManager.i.PlayBallHit();
                

                break;

            case Constants.COLLECTOR:
                GameController.i.GameOver();
                break;
        }



    }
    private void Update()
    {

        if (!isPC)
            dirX = Input.acceleration.x * moveSpeed;
        else
        {
            dirX = Input.GetAxis("Horizontal") * moveSpeed;
        }

        if (transform.position.x < -boundary)
        {

            transform.position = new Vector2(boundary, transform.position.y);
        }
        else if (transform.position.x > boundary)
        {

            transform.position = new Vector2(-boundary, transform.position.y);
        }


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    public void Reset()
    {
        transform.position = initPos;
        rb.velocity = Vector2.zero;
        dirX = 0;
    }
}
