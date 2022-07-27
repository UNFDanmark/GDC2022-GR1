using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    public TextMeshProUGUI textTimer;


   

    

    // Start is called before the first frame update
    void Start()
    {
        time.timeLimit = 60;
    }

    // Update is called once per frame
    void Update()
    {
        textTimer.text = time.timeLimit.ToString() + "S";

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
        if(time.timeLimit < 100)
        {
            time.timeLimit += 10;

        }
    }

    public void lessTime()
    {

        if (time.timeLimit >= 30)
        {
            time.timeLimit -= 10;

        }
    }
}

