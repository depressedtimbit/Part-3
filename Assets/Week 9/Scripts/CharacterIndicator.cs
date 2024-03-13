using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;

    
    void Update() 
    {
        if (CharacterControl.SelectedVillager == null)
        {
            text.text = "None";
        }
        else 
        {
            text.text = CharacterControl.SelectedVillager.GetType().Name;
        }
    }
}
