using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{
    public TextMeshProUGUI CurrencyText;
    public TextMeshProUGUI PercentageText;
    public GameObject endScreen;
    public int percentage;

    void Start()
    {
        StartCoroutine(addPercentage());
    }

    void Update()
    {
        CurrencyText.text = Registry.profile.Data.currency + "";
        PercentageText.text = percentage + "%";
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
        Registry.profile.Save();
        //endScreen.SetActive(true);
        SceneManager.LoadScene("Spacemap");
    }
}
