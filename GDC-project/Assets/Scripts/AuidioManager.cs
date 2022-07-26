using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sfx
{
    voiceLine, hitSound, blockSound, Cowbell, wooshSound
}

public class AuidioManager : MonoBehaviour
{

    public AudioSource SFXSource;

    public AudioClip[] hitSounds;
    public AudioClip[] blocktSounds;
    public AudioClip[] voiceLines;
    public AudioClip cowBell;
    public AudioClip wooshSound;

    public sfx sfxMode;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playSound(sfxMode);
        }
    }

    public void playSound(sfx soundMode)
    {
        sfxMode = soundMode;

        switch (sfxMode)
        {
            case sfx.voiceLine:

                SFXSource.PlayOneShot(voiceLines[Random.Range(0,voiceLines.Length)]);

                break;
            case sfx.hitSound:

                SFXSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Length)]);

                break;
            case sfx.blockSound:

                SFXSource.PlayOneShot(blocktSounds[Random.Range(0, blocktSounds.Length)]);

                break;
            case sfx.Cowbell:

                SFXSource.PlayOneShot(cowBell);

                break;
            case sfx.wooshSound:

                SFXSource.PlayOneShot(wooshSound);

                break;
            default:
                break;
        }





    }




}
