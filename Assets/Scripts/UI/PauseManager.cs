using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel, playerUI;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        //pausePanel.SetActive(false);
        CursorState(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGane();
            }
        }
    }

    //Funcion para pausar
    public void PauseGane()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        playerUI.SetActive(false);
        CursorState(true);
        Time.timeScale = 0f;
    }

    //Funcion para reaunudar juego
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        playerUI.SetActive(true);
        CursorState(false);
        Time.timeScale = 1f;
    }

    //Funcion para activar y desactivar cursor
    public void CursorState(bool _state)
    {
        Cursor.visible = _state;    
        if (_state )
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
