using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool player1 =true;

    public float speed;
    public float turnSpeed = 1;
    public float attackforce;
    public float rotationforce;
    float lastAttackTime = -100f;
    public float attackLength = 0.8f;
    Rigidbody rb;
    Vector3 attackDirection;
    public int health = 3;

    //block
    Vector3 blockDirection;
    float lastBlockTime = -100f;
    public float blockLength;
    public float blockForce;
    public bool isAttacking;

    public GameObject swordCollider;
    public GameObject blockCollider;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            //respawn code

            //Death count code
        } 



    
        if (player1)
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

                attackDirection = transform.forward * attackforce;

                lastAttackTime = Time.time;



            }


            isAttacking = lastAttackTime + attackLength >= Time.time;

            if (isAttacking)
            {
                rb.velocity = attackDirection;
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * rotationforce);

                swordCollider.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                swordCollider.GetComponent<BoxCollider>().enabled = false;
            }


            bool blockInput = Input.GetKeyDown(KeyCode.E);
            if (blockInput)
            {

                blockDirection = transform.forward * blockForce;

                lastBlockTime = Time.time;

            }

            bool isBlocking = lastBlockTime + blockLength >= Time.time;

            if (isBlocking)
            {
                rb.velocity = -blockDirection;
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * -rotationforce);

                blockCollider.GetComponent<BoxCollider>().enabled=true;
            }
            else
            {
                blockCollider.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            float moveInput = Input.GetAxis("Player2 Vertical");//Variable for move input
            float turnInput = Input.GetAxis("Player2 Horizontal");


            float moveSpeed = speed * moveInput;

            Vector3 newVelocity = transform.forward * moveSpeed;
            newVelocity.y = rb.velocity.y;
            rb.velocity = newVelocity; //Sets velocity of the player to movespeed in the forward direction

            gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the player around Y-axis

            bool attackInput = Input.GetKeyDown(KeyCode.PageUp);
            if (attackInput)
            {

                attackDirection = transform.forward * attackforce;

                lastAttackTime = Time.time;



            }


            bool isAttacking = lastAttackTime + attackLength >= Time.time;

            if (isAttacking)
            {
                rb.velocity = attackDirection;
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * rotationforce);

                swordCollider.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                swordCollider.GetComponent<BoxCollider>().enabled = false;
            }


            bool blockInput = Input.GetKeyDown(KeyCode.PageDown);
            if (blockInput)
            {

                blockDirection = transform.forward * blockForce;

                lastBlockTime = Time.time;

            }

            bool isBlocking = lastBlockTime + blockLength >= Time.time;

            if (isBlocking)
            {
                rb.velocity = -blockDirection;
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * -rotationforce);

                blockCollider.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                blockCollider.GetComponent<BoxCollider>().enabled = false;
            }

        }

        
        




    }


    public void takeDamage(int damageToTake)
    {
        health -= damageToTake;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isSword = collision.gameObject.tag == "Sword";
       

        if (isSword)
        {
            takeDamage(1);
        }
        
    }

}
