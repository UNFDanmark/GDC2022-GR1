using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject OptionMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void options()
    {
        mainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void mainMenu_()
    {
        mainMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }
    public void quit()
    {
        Application.Quit();
    }
}
