using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed;
    public float turnSpeed = 1;
    public float attackforce;
    public float rotationforce;
    float lastAttackTime = -100f;
    public float attackLength = 0.8f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        float moveInput = Input.GetAxis("Vertical");//Variable for move input
        float turnInput = Input.GetAxis("Horizontal");

        float moveSpeed = speed * moveInput;

        Vector3 newVelocity = transform.forward * moveSpeed;
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity; //Sets velocity of the player to movespeed in the forward direction

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the player around Y-axis

        bool attackInput = Input.GetKeyDown(KeyCode.Q);
        if (attackInput)
        {


            //rb.rotation = transform.rotation * rotationforce;
            lastAttackTime = Time.time;

        }

        bool isAttacking = lastAttackTime + attackLength >= Time.time;

        if (isAttacking)
        {
            rb.velocity = (transform.forward * attackforce);
        }


        

    }

    


}
