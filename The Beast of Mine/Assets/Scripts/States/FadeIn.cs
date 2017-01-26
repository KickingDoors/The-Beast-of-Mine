using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : StateMachineBehaviour {

    public float fadeDuration = 1;
    void OnStateEnter()
    {
        FadeManager.Init(fadeDuration, FadeManager.FADE_IN);
    }
}
