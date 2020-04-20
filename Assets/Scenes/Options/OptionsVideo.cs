using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OptionsVideo : MonoBehaviour
{
    public GameObject panel;
    void Start() { gameObject.GetComponent<VideoPlayer>().loopPointReached += CheckOver; }

    void CheckOver(VideoPlayer vp)
    {
        panel.SetActive(false);
    }

}
