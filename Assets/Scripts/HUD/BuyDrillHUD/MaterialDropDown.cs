using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MaterialDropDown : MonoBehaviour
{
    private void Start()
    {
        Planet planet = new Planet();
        planet.Load(Registry.profile.Data.current_planet);
        for (var i = 0; i < planet.Data.materials.Count; i++)
        {
            gameObject.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData(planet.Data.materials[i].ToString()));
            GetComponent<TMP_Dropdown>().value = i;
        }
    }
}
