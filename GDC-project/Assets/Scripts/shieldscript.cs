using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shieldscript : MonoBehaviour
{
    public float knockbackForce;
    public GameObject opponent;
    public GameObject player;
    AuidioManager audioManager;
    public GameObject healthBar;
    public playerMovement playerInv;



    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AuidioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool isSword = collision.gameObject.tag == "Sword";


        if (isSword)
        {
            print("hit");

            audioManager.playSound(sfx.blockSound);
            audioManager.playSound(sfx.voiceLineBlock);
            //Vector3 direction=collision.transform.position;

            Vector3 direction=player.GetComponent<Transform>().position - opponent.GetComponent<Transform>().position ;

            opponent.GetComponent<Rigidbody>().velocity = -direction * knockbackForce;

            opponent.GetComponent<playerMovement>().health -= 1;
            playerInv.invounrabilitytime = 1;
            


            Image healthUIImage = healthBar.GetComponent<Image>();
            healthUIImage.fillAmount = (float)opponent.GetComponent<playerMovement>().health / (float)3;


        }
        

    }
}
