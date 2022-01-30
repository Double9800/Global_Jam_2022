using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject EndGamePanel, HUD, PauseMenu;
    void Start()
    {
        EndGamePanel.SetActive(false);
        HUD.SetActive(true);
        PauseMenu.SetActive(true);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            EndGamePanel.SetActive(true);
            Debug.Log("Esta Funzionando");
            StartCoroutine("WaitForSec");

            Time.timeScale = 0;
            HUD.SetActive(false);
            PauseMenu.SetActive(false);
        }
    }
}
