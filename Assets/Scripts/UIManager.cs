using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private GameObject winPanel;

    [SerializeField]
    private GameObject startPanel;

    [SerializeField]
    private TMP_Text endTimeOnWinPanel;

    [SerializeField]
    private List<GameObject> tracks = new List<GameObject>();

    Timer timerObj;

    AudioManager audioManager;

    public bool onStart = true;
    public bool isGameOver = false;
    public bool isWin = false;

    private int currentTrackSelected = 0;

    Color32 selectedColor = new Color32(40, 216, 255, 255);

    void Start()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive (false);
        winPanel.SetActive(false);
        startPanel.SetActive(true);
        timerObj = GetComponent<Timer>();
        audioManager = GameObject.Find("MusicManager").GetComponent<AudioManager>();
        tracks[currentTrackSelected].GetComponent<TMP_Text>().color = selectedColor;
    }

    void Update()
    {
        if(onStart)
        {
            AudioManager.instance.InPanel(0f);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                onStart = false;
                startPanel.SetActive(false);
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ClearTrackColors();
                currentTrackSelected = 0;
                tracks[currentTrackSelected].GetComponent<TMP_Text>().color = selectedColor;
                audioManager.StartTrack("Track 1");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ClearTrackColors();
                currentTrackSelected = 1;
                tracks[currentTrackSelected].GetComponent<TMP_Text>().color = selectedColor;
                audioManager.StartTrack("Track 2");
            }

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                ClearTrackColors();
                currentTrackSelected = 2;
                tracks[currentTrackSelected].GetComponent<TMP_Text>().color = selectedColor;
                audioManager.StartTrack("Track 3");
            }
        }

        if (isGameOver || isWin)
        {
            Time.timeScale = 0;
            AudioManager.instance.InPanel(1f);

            if(isWin)
            {
                endTimeOnWinPanel.text = timerObj.FinalTime();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ClearTrackColors()
    {
        foreach(var track in tracks)
        {
            track.GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void ShowGameOverScreen()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void ShowWinScreen()
    {
        isWin = true;
        winPanel.SetActive(true);
    }
}
