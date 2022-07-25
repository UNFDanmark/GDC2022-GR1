using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capselscript : MonoBehaviour
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
    public void EndOfAttack()
    {
        Transform capsuleTransform = GetComponent<Transform>();

        player.GetComponent<Transform>().SetPositionAndRotation(capsuleTransform.position, capsuleTransform.rotation);
    }
}

