using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameUI : MonoBehaviour
{

    public GameObject gameUI;
    public GameObject winUI;

    public TextMeshProUGUI playerTxt;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(time.timeLimit <= 0)
        {
            winScreen();
        }
    }


    public void winScreen()
    {
        gameUI.SetActive(false);
        winUI.SetActive(true);


    }
    public void returnToMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }

}
