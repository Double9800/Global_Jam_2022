using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI, HUD;
    public PlayerHealth MyPlayer;

    private void Start()
    {
        HUD.SetActive(true);
        MyPlayer = FindObjectOfType<PlayerHealth>();
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        HUD.SetActive(true);
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()

    {
        Time.timeScale = 0f;
        HUD.SetActive(false);
        PauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        HUD.SetActive(true);
        MyPlayer.transform.position = MyPlayer.SpawnPoint.transform.position;
        MyPlayer.lifeCounter = 9;
        SceneManager.LoadScene(0);
        PauseMenuUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}