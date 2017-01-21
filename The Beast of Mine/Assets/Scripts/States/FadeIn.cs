using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : StateMachineBehaviour {

    public float fadeDuration = 1;
    void OnStateEnter()
    {
        GameObject fadeCanvas = GameObject.Find("FadeCanvas");
        fadeCanvas.AddComponent<FadeManager>();
        fadeCanvas.GetComponent<FadeManager>().init(fadeCanvas, fadeDuration, FadeManager.FADE_IN);
    }
}
