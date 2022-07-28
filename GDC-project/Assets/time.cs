using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class time : MonoBehaviour
{

    public static float timeLimit;
    public float passedTime;
    int counter;
    public TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        



        if(counter < passedTime)
        {
            counter++;
            timeLimit --;
        }
        passedTime += Time.deltaTime;
        timer.text = timeLimit.ToString();

       
    }

  
}
