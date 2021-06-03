using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;

    // The function for quitting the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the game");
    }

    // The function for going to the options menu
    public void DisplayOptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    // The function for going back to main menu from options
    public void CloseOptionsMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    // The function to go to the conrtols menu
    public void DisplayControlsMenu()
    {
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    // The function for going back to options menu from controls menu
    public void CloseControlsMenu()
    {
        optionsMenu.SetActive(true);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    // The function that starts a new game
    public void StartNewGame()
    {
        //SceneManager.LoadScene("Level");
        SceneManager.LoadScene(1);
    }
}
