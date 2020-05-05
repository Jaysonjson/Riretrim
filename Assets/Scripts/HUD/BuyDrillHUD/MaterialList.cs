using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialList : MonoBehaviour
{
    public GameObject materialDummy;
    private void Start()
    {
        Planet planet = new Planet();
        planet.LoadUsingName(Profile.Data.current_planet);
        float lastObject = 0;
        for (var i = 0; i < planet.materials.Count; i++)
        {
            GameObject materialObject = Instantiate(materialDummy, gameObject.transform, false);
            materialObject.GetComponent<RectTransform>().position = new Vector3(materialObject.transform.position.x, (int)((materialObject.GetComponent<RectTransform>().position.y - lastObject)));
            materialObject.SetActive(true);
            //materialObject.GetComponent<Image>().sprite = References.sprite.MATERIALS_METAL;
            lastObject = materialObject.GetComponent<RectTransform>().position.y / 5;
        }
    }
}
