using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sfx
{
    voiceLineHit, voiceLineBlock, hitSound, blockSound, Cowbell, wooshSound, battleEnd, battlestart,
}

public class AuidioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    public AudioClip[] hitSounds;
    public AudioClip[] blocktSounds;


    public AudioClip[] voiceLinesBlcok;
    public AudioClip[] voiceLinesHit;

    public AudioClip[] voiceLineStart;
    public AudioClip[] voiceLinesEnd;

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
        SFXSource.volume = MainMenu.sfxVolume;
        MusicSource.volume = MainMenu.musicVolume;


        if (Input.GetKeyDown(KeyCode.V))
        {
            playSound(sfxMode);
        }
    }

    public void playSound(sfx soundMode)
    {
        int chance = Random.Range(0, 101);

        sfxMode = soundMode;

        switch (sfxMode)
        {
            case sfx.voiceLineBlock:


                if(chance > 80)
                {
                    SFXSource.PlayOneShot(voiceLinesBlcok[Random.Range(0, voiceLinesBlcok.Length)], 0.2f);

                }


                break;
            case sfx.voiceLineHit:
              

                if (chance > 80)
                {
                    SFXSource.PlayOneShot(voiceLinesHit[Random.Range(0, voiceLinesHit.Length)], 0.2f);
                }
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
            case sfx.battlestart:
                if (chance > 80)
                {
                    SFXSource.PlayOneShot(voiceLineStart[Random.Range(0, voiceLineStart.Length)], 0.2f);
                }
                break;
            case sfx.battleEnd:
                
                    SFXSource.PlayOneShot(voiceLinesEnd[Random.Range(0, voiceLinesEnd.Length)], 0.2f);
                
                break;
            default:
                break;
        }





    }




}
