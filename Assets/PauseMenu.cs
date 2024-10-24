using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject optionsButton;
    public GameObject soundsSlider;

    AudioManager sounds;

    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Pause.started += ctx => PauseOrResume();
    }

    void Start()
    {
        sounds = FindObjectOfType<AudioManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }*/
    }

    public void PauseOrResume()
    {

        Debug.Log("Paused or REsumed");

        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        Debug.Log("Resumed");
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        sounds.Play("MenuCancel");
    }

    void Pause()
    {
        Debug.Log("Paused");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused= true;
    }

    public void LoadOptions()
    {
        Selector optionsSelector = optionsButton.GetComponent<Selector>();
        optionsSelector.OnPointerExit(null);
        sounds.Play("PressSelect");
        if (soundsSlider != null)
        {
            EventSystem.current.SetSelectedGameObject(soundsSlider);
        }
    }

    public void RestartRun()
    {
        Debug.Log("Restarting Run...");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        sounds.Play("PressSelect");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
