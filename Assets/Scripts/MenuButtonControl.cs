using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white; 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.color = Color.green;
    }
}