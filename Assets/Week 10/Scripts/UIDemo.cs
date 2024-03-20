using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class UIDemo : MonoBehaviour
{
    public SpriteRenderer sr;
    public Color startColor;
    public Color endColor;
    float interp;
    public TMP_Dropdown dropdown;
    public void SliderValueChanged(Single Value)
    {
        Debug.Log(Value);
        interp = Value;
    }

    private void Update()
    {
        sr.color = Color.Lerp(startColor, endColor, interp/60);
    }

    public void DropDownSelectionChanged(Int32 Value)
    {
        Debug.Log(dropdown.options[Value].text);
    }
}
