using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    private string musicEvent;

    EventInstance music;

    EventDescription musicDescription;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            //music = RuntimeManager.CreateInstance(musicEvent);
            //music.start();
            StartTrack("Track 1");
        }
        
    }


    //Track 1
    public void StartTrack(string trackSelect)
    {
        //FMOD.Studio.PLAYBACK_STATE musicState;
        //music.getPlaybackState(out musicState);
        //if (musicState == )
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

        switch(trackSelect)
        {
            case "Track 1":
                music = RuntimeManager.CreateInstance("event:/Music/GameTheme");
                music.start();
                break;
            case "Track 2":
                music = RuntimeManager.CreateInstance("event:/Music/GameTheme2");
                music.start();
                break;
            case "Track 3":
                music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                break;
            default:
                break;
        }
    }

    //Track 2

    // Update is called once per frame
    void Update()
    {
        
    }
}
