using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public bool player1 =true;
    public float invounrabilitytime;

    public int health = 3;
    public int deathCount;

    [Header("Movement variables")]
    public float rotationforce;
    public float speed;
    public float turnSpeed = 1;

    [Header("Attack Variables")]
    public float attackforce;
    
    public float attackLength = 0.8f;
    public float attackCooldownTime = 3;

    [Header("Blocking variables")]
    public float blockCooldownTime = 3;
    public float blockLength;
    public float blockForce;

    [Header("References")]
    public GameObject swordCollider;
    public GameObject blockCollider;
    public GameObject reaspawnPoint;
    public GameObject healthBar;
    public TextMeshProUGUI scoreText;
   
    AuidioManager audioManager;
    InGameUI inGameUI_;
    time timer;
    public playerMovement opponent;

    string playerWon;


    Rigidbody rb;
    Vector3 attackDirection;
    float lastBlockTime = -100f;



    //block
    Vector3 blockDirection;
    
    bool isAttacking;
    float lastAttackTime = -100f;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        lastAttackTime = Time.time - attackCooldownTime;
        audioManager = GameObject.Find("AudioManager").GetComponent<AuidioManager>();
        inGameUI_ = GameObject.Find("Camera").GetComponent<InGameUI>();
    }

    // Update is called once per frame
    void Update()
    {

        inGameUI_.playerTxt.text = playerWon;
        anim.SetFloat("Velocity", Mathf.Abs(rb.velocity.x)  + Mathf.Abs(rb.velocity.y));

        invounrabilitytime -= Time.deltaTime;

       if(time.timeLimit <= 0)
        {
            if (deathCount < opponent.deathCount)
            {
                Time.timeScale = 0;
                print("dadajwdkhawdwadhwa");
                playerWon = gameObject.name;
            }
        }

        if (health == 0 && time.timeLimit > 0)
        {
            audioManager.playSound(sfx.Cowbell);


            health = 3;
            GetComponent<Transform>().position = reaspawnPoint.GetComponent<Transform>().position;

            Image healthUIImage = healthBar.GetComponent<Image>();
            healthUIImage.fillAmount = (float)health / (float)3;


            deathCount += 1;

            scoreText.text = deathCount.ToString();
        } 



    
        if (player1)
        {
            float moveInput = Input.GetAxis("Vertical");//Variable for move input
            float turnInput = Input.GetAxis("Horizontal");



            float moveSpeed = speed * moveInput;

            Vector3 newVelocity = transform.forward * moveSpeed;
           
            rb.AddForce(newVelocity) ; //Sets velocity of the player to movespeed in the forward direction

            gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the player around Y-axis
            
            bool canAttack = lastAttackTime + attackCooldownTime <= Time.time;
            bool attackInput = Input.GetKeyDown(KeyCode.E);
            if (attackInput && canAttack)
            {
                audioManager.playSound(sfx.wooshSound);
                attackDirection = transform.forward * attackforce;

                lastAttackTime = Time.time;

                

            }


            isAttacking = lastAttackTime + attackLength >= Time.time;

            if (isAttacking )
            {
                rb.velocity = attackDirection;
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * -rotationforce);

               
                swordCollider.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                swordCollider.GetComponent<BoxCollider>().enabled = false;
            }

            bool canBlock = lastBlockTime + blockCooldownTime <= Time.time;
            bool blockInput = Input.GetKeyDown(KeyCode.Q);
            if (blockInput && canBlock)
            {
                audioManager.playSound(sfx.wooshSound);

                blockDirection = transform.forward * blockForce;

                lastBlockTime = Time.time;

            }

            bool isBlocking = lastBlockTime + blockLength >= Time.time;

            if (isBlocking)
            {
                rb.velocity = blockDirection;
                gameObject.GetComponent<Transform>().Rotate(Vector3.up * rotationforce);

                blockCollider.GetComponent<BoxCollider>().enabled = true;
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
            
            rb.AddForce(newVelocity) ; //Sets velocity of the player to movespeed in the forward direction

            gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the player around Y-axis

            bool canAttack = lastAttackTime + attackCooldownTime <= Time.time;
            bool attackInput = Input.GetKeyDown(KeyCode.U);
            if (attackInput && canAttack)
            {
                audioManager.playSound(sfx.wooshSound);

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

            bool canBlock = lastBlockTime + blockCooldownTime <= Time.time;
            bool blockInput = Input.GetKeyDown(KeyCode.O);
            if (blockInput && canBlock)
            {
                audioManager.playSound(sfx.wooshSound);

                blockDirection = transform.forward * blockForce;

                lastBlockTime = Time.time;

            }

            bool isBlocking = lastBlockTime + blockLength >= Time.time;

            if (isBlocking)
            {

                rb.velocity = blockDirection;
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
        audioManager.playSound(sfx.hitSound);
        audioManager.playSound(sfx.voiceLineHit);


    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isSword = collision.gameObject.tag == "Sword";


        bool invounrability = invounrabilitytime < 0;

        if (isSword && invounrability)
        {
            takeDamage(1);

            invounrabilitytime = 1;

            Image healthUIImage = healthBar.GetComponent<Image>();
            healthUIImage.fillAmount = (float)health / (float)3;


        }
    }
}
