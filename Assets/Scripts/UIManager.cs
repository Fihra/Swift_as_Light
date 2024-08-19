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

    public bool isGameOver = false;

    public bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "0:00";
        gameOverPanel.SetActive (false);
        winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
