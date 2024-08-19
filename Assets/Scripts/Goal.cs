using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    UIManager winPanelUI;
    // Start is called before the first frame update
    void Start()
    {
        winPanelUI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            winPanelUI.ShowWinScreen();
            Debug.Log("You win!");
        }
    }
}
