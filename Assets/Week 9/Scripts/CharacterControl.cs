using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    

    public static Villager[] villagers;
    public static CharacterControl Instance;
    public static Villager SelectedVillager { get; private set; }

    public void Start() 
    {
        Instance = this;
        villagers = FindObjectsOfType<Villager>();
        var villagerOptions = new List<TMP_Dropdown.OptionData>();

        foreach(Villager villager in villagers)
        {
            villagerOptions.Add(new TMP_Dropdown.OptionData(villager.GetType().ToString(), villager.SelectionSprite));
        }
        dropdown.AddOptions(villagerOptions);

    }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        
    }

    public void SelectionValueChanged(Int32 value)
    {
        SetSelectedVillager(villagers[value]);
    }
}
