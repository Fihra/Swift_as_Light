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
    private GameObject timerUI;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private GameObject startPanel;

    public bool onStart = true;
    public bool isGameOver = false;
    public bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "0:00";
        Time.timeScale = 0;
        gameOverPanel.SetActive (false);
        winPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(onStart)
        {
            Debug.Log("Hi first??");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Hi??");
                onStart = false;
                startPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }

        if (isGameOver || isWin)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        //if (isWin)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    }
        //}
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
