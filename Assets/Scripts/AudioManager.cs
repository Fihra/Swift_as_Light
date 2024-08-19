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
            music = RuntimeManager.CreateInstance(musicEvent);
            music.start();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
