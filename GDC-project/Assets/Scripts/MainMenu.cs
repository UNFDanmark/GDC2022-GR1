using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject OptionMenu;

    public static float sfxVolume;
    public static float musicVolume;

    public Slider sfxSlider;
    public Slider musicSlider;

    public AudioSource music;
    public AudioSource sfxV;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sfxVolume = sfxSlider.value;
        musicVolume = musicSlider.value;

        music.volume = musicVolume;
        sfxV.volume = sfxVolume;
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


    public void moreTime()
    {
    }

    public void lessTime()
    {
   }
}

