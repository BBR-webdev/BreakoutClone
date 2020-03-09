using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    // variables for racket movement speed and direction/orientation
    public float speed = 30;
    public string axis = "Horizontal";

    // Function that updates on fixed time interval; includes velocity calculation for the racket
    void FixedUpdate()
    {
        float direction = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction, 0) * speed;
    }


}
