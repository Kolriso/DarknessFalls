using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;
    public GameObject alertBox;
    public AudioSource source;
    public AudioClip click;
    public AudioMixer mixer;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Animator animator;
    
    // The function for the Master Slider
    public void ChangeMasterVolume(float masterVolume)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(masterVolume) * 20);
    }

    // The function for the sfx slider
    public void ChangeSFXVolume(float sfxVolume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
        //Save();
    }

    // The function for the music slider
    public void ChangeMusicVolume(float musicVolume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
        //Save();
    }

    // The function that loads the previous settings
    public void LoadOptions()
    {
        float mixerMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        mixer.SetFloat("MasterVolume", mixerMasterVolume);
        float masterSliderValue = PlayerPrefs.GetFloat("MasterVolumeSlider", 1f);
        masterVolumeSlider.value = masterSliderValue;
        float mixerMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        mixer.SetFloat("MusicVolume", mixerMusicVolume);
        float musicSliderValue = PlayerPrefs.GetFloat("MusicVolumeSlider", 1f);
        musicVolumeSlider.value = musicSliderValue;
        float mixerSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);
        mixer.SetFloat("SFXVolume", mixerSFXVolume);
        float sfxSliderValue = PlayerPrefs.GetFloat("SFXVolumeSlider", 1f);
        sfxVolumeSlider.value = sfxSliderValue;
    }

    // The function that save the current settings
    public void SaveOptions()
    {
        float mixerMasterVolume;
        float mixerMusicVolume;
        float mixerSFXVolume;
        mixer.GetFloat("MasterVolume", out mixerMasterVolume);
        mixer.GetFloat("MusicVolume", out mixerMusicVolume);
        mixer.GetFloat("SFXVolume", out mixerSFXVolume);
        PlayerPrefs.SetFloat("MasterVolume", mixerMasterVolume);
        PlayerPrefs.SetFloat("MasterVolumeSlider", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", mixerMusicVolume);
        PlayerPrefs.SetFloat("MusicVolumeSlider", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", mixerSFXVolume);
        PlayerPrefs.SetFloat("SFXVolumeSlider", sfxVolumeSlider.value);
    }

    // The function that activates right as soon as you press play
    private void Start()
    {
        // animator = GetComponent<Animator>();

        // The if statement that checks if there is a previous option settings
        if (!PlayerPrefs.HasKey("MusicVolume") && !PlayerPrefs.HasKey("SFXVolume") && !PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolumeSlider", 1f);
            PlayerPrefs.SetFloat("MasterVolume", 0f);
            PlayerPrefs.SetFloat("MusicVolumeSlider", 1f);
            PlayerPrefs.SetFloat("MusicVolume", 0f);
            PlayerPrefs.SetFloat("SFXVolumeSlider", 1f);
            PlayerPrefs.SetFloat("SFXVolume", 0f);
            LoadOptions();
        }
        else
        {
            LoadOptions();
        }
    }

    // The function for making a button produce sound
    public void OnButtonPressed()
    {
        source.PlayOneShot(click);
    }

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
        alertBox.SetActive(false);
        animator.SetTrigger("ButtonClicked");
    }

    // The function for going back to main menu from options
    public void CloseOptionsMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        alertBox.SetActive(false);
    }

    // The function to go to the conrtols menu
    public void DisplayControlsMenu()
    {
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        alertBox.SetActive(false);
    }

    // The function for going back to options menu from controls menu
    public void CloseControlsMenu()
    {
        optionsMenu.SetActive(true);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(false);
        alertBox.SetActive(false);
    }

    // The function that starts a new game
    public void StartNewGame()
    {
        GameManager.Instance.ChangeGameState(GameManager.GameState.PLAYING);
        SceneManager.LoadScene("Level");
        //SceneManager.LoadScene(1);
        animator.SetTrigger("ButtonClicked");
    }

    public void CheckForChanges()
    {
        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        float actualMasterVolume;
        mixer.GetFloat("MaterVolume", out actualMasterVolume);
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0f);
        float actualMusicVolume;
        mixer.GetFloat("MusicVolume", out actualMusicVolume);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0f);
        float actualSFXVolume;
        mixer.GetFloat("SFXVolume", out actualSFXVolume);
        if (Mathf.Approximately(savedMasterVolume, actualMasterVolume) && Mathf.Approximately(savedMusicVolume, actualMusicVolume) && Mathf.Approximately(savedSFXVolume, actualSFXVolume))
        {
            // The values are the same
            CloseOptionsMenu();
        }
        else
        {
            // The Values are different
            ShowAlertBox();
        }
    }

    public void ShowAlertBox()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        controlsMenu.SetActive(false);
        alertBox.SetActive(true);
    }

    public void CloseAlertBox()
    {
        alertBox.SetActive(false);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);

    }
}
