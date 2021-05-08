// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using UnityEngine.UI;
//
// public class PlayGameMenuHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
// {
//     public Button play, tutorial;
//     
//     public void OnPointerEnter(PointerEventData eventData)
//     {
//         play.gameObject.SetActive(true);
//         tutorial.gameObject.SetActive(true);
//     }
//
//     public void OnPointerExit(PointerEventData eventData)
//     {
//         var enumerator = Waiter();
//     }
//
//     IEnumerator Waiter()
//     {
//         yield return new WaitForSeconds(4);
//         play.gameObject.SetActive(false);
//         tutorial.gameObject.SetActive(false);
//     }
//     
//     public void 
// }
