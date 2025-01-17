using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsButton;
    public GameObject soundsSlider;

    AudioManager sounds;

    private void Start()
    {
        sounds = FindObjectOfType<AudioManager>();
    }

    public void PlayGame()
    {
        sounds.Play("PressSelect");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This method stops the selector gems from showing
    public void OpenOptions()
    {
        sounds.Play("PressSelect");
        Selector optionsSelector = optionsButton.GetComponent<Selector>();
        optionsSelector.OnPointerExit(null);
        if (soundsSlider != null)
        {
            EventSystem.current.SetSelectedGameObject(soundsSlider);
        }
    }

    public void QuitGame()
    {
        sounds.Play("PressSelect");
        Debug.Log("Quit");
        Application.Quit();
    }
}
