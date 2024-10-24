using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Selector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public GameObject[] objectsToShow; // The objects to show when the player hovers over the button

    AudioManager sounds;

    private void Awake()
    {
       sounds = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {

        // Hide the objects at the start
        foreach (var obj in objectsToShow)
        {
            obj.SetActive(false);
        }

        //sounds = FindObjectOfType<AudioManager>();
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

    public void OnSelect(BaseEventData eventData)
    {
        OnPointerEnter(null);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        OnPointerExit(null);
    }
}