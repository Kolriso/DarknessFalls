using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(HandleContinue);
        restartButton.onClick.AddListener(HandleRestart);
        optionsButton.onClick.AddListener(HandleOptions);
        quitButton.onClick.AddListener(HandleContinue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleContinue()
    {
        GameManager.Instance.TogglePause();
    }

    public void HandleRestart()
    {
        animator.SetTrigger("ButtonClicked");
        GameManager.Instance.RestartGame();
    }

    public void HandleOptions()
    {
        GameManager.Instance.PauseOptionsMenu();
    }

    public void HandleQuit()
    {
        GameManager.Instance.QuitGame();
    }
}
