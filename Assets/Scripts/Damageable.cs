using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Damageable : MonoBehaviour
{
    UIManager gameOverUI;

    private void Start()
    {
        gameOverUI = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameOverUI.ShowGameOverScreen();
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Death_SFX");
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }
}
