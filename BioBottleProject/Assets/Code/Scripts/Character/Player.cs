using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject gamePause;

    [SerializeField] private Spawn spawn;
     private Pause pause;

    private bool isPaused = false;

    private void Start(){
        gamePause.SetActive(false);
        gameOverScreen.SetActive(false);
    }

    public void DeathByEnemy(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*gameObject.SetActive(false);

        spawn.RespawnPlayer();
        gameObject.SetActive(true);*/
    }
    public void DeathByBoss()
    {
        gameOverScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            isPaused = !isPaused;
            if (isPaused)
            {
                gamePause.SetActive(true);
                pause.MenuPause();
            }
            else
            {
                gamePause.SetActive(false);
                pause.ResumeGame();
            }
        }
    }
}
