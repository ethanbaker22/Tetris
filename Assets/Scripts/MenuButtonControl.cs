using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/**
 * MenuButtonControl.cs
 * @author Ethan Baker - 986237
 *
 * Deals with updating the Text Colour
 */
public class MenuButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;

    // Changes Colour Red On Enter
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.red;
    }

    // Changes Colour White On Exit
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.color = Color.green;
    }
}