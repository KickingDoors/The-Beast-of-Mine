using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : StateMachineBehaviour
{

    public float fadeDuration = 1;
    void OnStateExit()
    {
        GameObject fadeCanvas = GameObject.Find("FadeCanvas");
        fadeCanvas.AddComponent<FadeManager>();
        fadeCanvas.GetComponent<FadeManager>().init(fadeCanvas, fadeDuration, FadeManager.FADE_OUT);
    }
}
