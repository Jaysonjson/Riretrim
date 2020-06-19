using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject cameraMain;
    public GameObject[] particles;
    private void Start()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(2f);
        while (gameObject.transform.localScale.x > 0f)
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3((float)(gameObject.transform.localScale.x - 0.01), (float)(gameObject.transform.localScale.x - 0.01), (float)(gameObject.transform.localScale.x - 0.01));
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].GetComponent<ParticleSystem>().transform.localScale = new Vector3((float)(particles[i].GetComponent<ParticleSystem>().transform.localScale.x - 0.01), (float)(particles[i].GetComponent<ParticleSystem>().transform.localScale.x - 0.01), (float)(particles[i].GetComponent<ParticleSystem>().transform.localScale.x - 0.01));
            }
        }
        gameObject.SetActive(false);
    }
    
    void Update()
    {
        gameObject.transform.position = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, -26.33833f);
    }
}
