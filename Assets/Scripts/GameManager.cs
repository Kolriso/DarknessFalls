using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Events.EventGameStateChanged OnGameStateChanged = new Events.EventGameStateChanged();
    public enum GameState { MAINMENU, OPTIONSMENU, CONTROLSMENU, PLAYING, PAUSED, PAUSEDOPTIONS, PAUSEDCONTROLS, ALERTBOX };
    private GameState currentGameState = GameState.MAINMENU;
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }
        private set
        {
            currentGameState = value;
        }
    }

    public static GameManager Instance; // Creating the variable for the game manager


    public void ChangeGameState(GameState newGameState)
    {
        GameState previousGameState = currentGameState;
        currentGameState = newGameState;

        switch (currentGameState)
        {
            case GameState.MAINMENU:
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
                break;
            case GameState.OPTIONSMENU:
                Time.timeScale = 1f;
                break;
            case GameState.CONTROLSMENU:
                Time.timeScale = 1f;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0f;
                break;
            case GameState.PAUSEDOPTIONS:
                Time.timeScale = 0f;
                break;
            case GameState.PAUSEDCONTROLS:
                Time.timeScale = 0f;
                break;
            case GameState.PLAYING:
                Time.timeScale = 1f;
                break;
            default:
                Debug.LogWarning("Unimplemented game state!");
                break;
        }
        OnGameStateChanged.Invoke(newGameState, previousGameState);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the game");
    }

    public void PauseOptionsMenu()
    {
        ChangeGameState(GameState.PAUSEDOPTIONS);
    }

    public void PauseControlsMenu()
    {
        ChangeGameState(GameState.PAUSEDCONTROLS);
    }

    public void RestartGame()
    {
        ChangeGameState(GameState.MAINMENU);
    }

    public void TogglePause()
    {
        if (currentGameState == GameState.PAUSED)
        {
            ChangeGameState(GameState.PLAYING);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
        else
        {
            ChangeGameState(GameState.PAUSED);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Runs right before Start()
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Debug.LogWarning("Attempted to create a second GameManager");
            Destroy(this);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGameState != GameState.MAINMENU)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }
}
