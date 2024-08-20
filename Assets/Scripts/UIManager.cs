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

    Timer timerObj;

    AudioManager audioManager;

    public bool onStart = true;
    public bool isGameOver = false;
    public bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive (false);
        winPanel.SetActive(false);
        startPanel.SetActive(true);
        timerObj = GetComponent<Timer>();
        audioManager = GameObject.Find("MusicManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onStart)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                onStart = false;
                startPanel.SetActive(false);
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                audioManager.StartTrack("Track 1");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                audioManager.StartTrack("Track 2");
            }

            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                audioManager.StartTrack("Track 3");
            }
        }

        if (isGameOver || isWin)
        {
            Time.timeScale = 0;

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
