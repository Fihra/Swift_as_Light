using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    UIManager uiManager;

    [SerializeField]
    private TMP_Text timerText;

    private float totalSeconds = 0;

    private string finalTime = "00:00";

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        timerText.text = "0:00";
    }

    public string FinalTime()
    {
        return finalTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.time);
        totalSeconds += Time.deltaTime;
        //Debug.Log($"Seconds: {(int)totalSeconds}");
        //Debug.Log($"Minutes: {(int)totalSeconds / 60}");

        string updatedTime = $"{(int)totalSeconds / 60}:{(int)totalSeconds % 60}";
        timerText.text = updatedTime;

        if (uiManager.isWin)
        {
            finalTime = updatedTime;
            FinalTime();
        }
        

       
    }
}
