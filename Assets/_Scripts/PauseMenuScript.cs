using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool isPaused;
    private GameObject pauseCanvas, gameOverCanvas;


    void Start()
    {
        pauseCanvas = gameObject.transform.GetChild(4).gameObject;
        gameOverCanvas = gameObject.transform.GetChild(5).gameObject;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && !gameOverCanvas.activeInHierarchy) 
        {
            GameManager.instance.GetComponent<AudioSource>().Pause();
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            GameManager.instance.GetComponent<AudioSource>().UnPause();
            pauseCanvas.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void ResumeGame()
    {
        GameManager.instance.GetComponent<AudioSource>().UnPause();
        pauseCanvas.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        pauseCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
