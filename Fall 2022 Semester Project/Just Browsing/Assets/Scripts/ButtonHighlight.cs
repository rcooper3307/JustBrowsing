using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject text;

    public void Awake()
    {
        text.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData context)
    {
        text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData context)
    {
        text?.SetActive(false);
    }
}
