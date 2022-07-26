using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
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
           
            Vector3 direction=collision.transform.forward;

            player.GetComponent<Rigidbody>().velocity = direction*100;
        }


    }
}

