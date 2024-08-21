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

    float normalParameter = 0;
    float lowPassParamter = 1f;

    PARAMETER_ID parameterID;

    PARAMETER_DESCRIPTION lowPassPanel;

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
            StartTrack("Track 1");
        }
        
    }

    public void StartTrack(string trackSelect)
    {
        music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        InPanel(normalParameter);

        switch(trackSelect)
        {
            case "Track 1":
                music = RuntimeManager.CreateInstance("event:/Music/GameTheme");
                music.getDescription(out musicDescription);
                music.start();
                break;
            case "Track 2":
                music = RuntimeManager.CreateInstance("event:/Music/GameTheme2");
                music.getDescription(out musicDescription);
                music.start();
                break;
            case "Track 3":
                music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                break;
            default:
                break;
        }
    }

    public void InPanel(float num)
    {
        musicDescription.getParameterDescriptionByName("Game Over", out lowPassPanel);
        music.setParameterByID(lowPassPanel.id, num);
    }
}
