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
        planet.LoadUsingName(Registry.profile.Data.current_planet);
        for (var i = 0; i < planet.materials.Count; i++)
        {
            gameObject.GetComponent<TMP_Dropdown>().options.Add(new TMP_Dropdown.OptionData(planet.materials[i].ToString()));
        }
    }
}
