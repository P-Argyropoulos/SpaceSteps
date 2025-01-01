using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private GameObject gameOverCanvas;
    private PlayerController playerController;
    private CrosshairScript aiming;
    private Shooting shoot1,shoot2;
    void Start()
    {
        gameOverCanvas = gameObject.transform.GetChild(5).gameObject;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        aiming = GameObject.Find("CrossHair").GetComponent<CrosshairScript>();
        shoot1 = GameObject.Find("Player").transform.GetChild(1).GetChild(0).GetComponent<Shooting>();
        shoot2 = GameObject.Find("Player").transform.GetChild(4).GetChild(0).GetComponent<Shooting>();
    }

    
    void Update()
    {
        if (GameManager.instance.stationCurrentHealth <= 0  )
        {
            gameOverCanvas.SetActive(true);
            playerController.enabled = false;

            aiming.enabled = false;
            shoot1.enabled = false;
            shoot2.enabled = false;
            
            PauseMenuScript.isPaused = false;
            Cursor.visible = true;
        } 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Space Steps"); 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("GAME EXIT!");
        Application.Quit();
    }
}
