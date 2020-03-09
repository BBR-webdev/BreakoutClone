using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Ball movement speed 
    public float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // method to calculate hit Factor for angled shots

        float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
        {
            // ascii art:
            //
            // 1  -0.5  0  0.5   1  <- x value
            // ===================  <- racket
            //

            return (ballPos.x - racketPos.x) / racketWidth;

            

        }

        // Check if collider is racket and if true, execute
        if (collision.gameObject.name == "racket")
        {
            // Feed data where ball was hit: and calculate the fireback angle
            // transform.position is ball position in worldspace. 
            // collision.transform.position is position of the part of the racket that hit
            // collider.bounds.size.x is the width ofthe racket
            float angleCalc = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(angleCalc, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;

        }
    }

}
