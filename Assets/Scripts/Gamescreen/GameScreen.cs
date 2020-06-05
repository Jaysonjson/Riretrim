﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{
    public TextMeshProUGUI CurrencyText;
    public TextMeshProUGUI PercentageText;
    public GSPlayer player;
    public int percentage;

    void Start()
    {
        StartCoroutine(addPercentage());
    }

    void Update()
    {
        CurrencyText.text = Registry.profile.Data.currency + "";
        PercentageText.text = percentage + "%";
        if (Registry.profile.Data.health <= 0)
        {
            Registry.profile.Data.health = 0.25f;
            Registry.profile.Save();
            SceneManager.LoadScene("SpaceMap");
        }
    }

    IEnumerator addPercentage()
    {
        yield return new WaitForSeconds(2.85f);
        if (percentage < 100) {
            percentage++;
            StartCoroutine(addPercentage());
        } else
        {
            onEnd();
        }
    }

    void onEnd()
    {
        Star star = RiretrimUtility.getStar(RiretrimUtility.GetGalaxy(Registry.profile.Data.current_galaxy), Registry.profile.Data.current_solarsystem);
        player.moveUp = true;
        star.Data.enemy_count--;
        Registry.profile.Save();
        //endScreen.SetActive(true);
    }
}
