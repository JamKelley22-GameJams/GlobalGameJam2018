using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagment;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused)
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
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }
}
