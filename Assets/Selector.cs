using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject[] objectsToShow; // The objects to show when the player hovers over the button

    AudioManager sounds;

    private void Start()
    {
        // Hide the objects at the start
        foreach (var obj in objectsToShow)
        {
            obj.SetActive(false);
        }

        sounds = FindObjectOfType<AudioManager>();
    }

    // Called when the mouse pointer enters the button's area
    public void OnPointerEnter(PointerEventData eventData)
    {

        sounds.Play("Select");

        // Show the objects
        foreach (var obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }

    // Called when the mouse pointer exits the button's area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the objects
        foreach (var obj in objectsToShow)
        {
            obj.SetActive(false);
        }
    }
}