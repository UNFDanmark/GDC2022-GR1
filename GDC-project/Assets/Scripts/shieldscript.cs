using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscript : MonoBehaviour
{
    public float knockbackForce;
    public GameObject opponent;
    public GameObject player;
    AuidioManager audioManager;
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

            //Vector3 direction=collision.transform.position;

            Vector3 direction=player.GetComponent<Transform>().position - opponent.GetComponent<Transform>().position ;

            opponent.GetComponent<Rigidbody>().velocity = -direction * knockbackForce;

        }


    }
}

