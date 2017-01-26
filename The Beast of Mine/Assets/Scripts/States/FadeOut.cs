using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class FadeOut : StateMachineBehaviour
{

    public float fadeDuration = 1;

    private MessageManager messageManager;
    void OnStateEnter()
    {
        messageManager = GameObject.Find("GameManager").GetComponent<MessageManager>();
        messageManager.SetHasFadeOut(true);
        messageManager.SetFadeOutScript(this);
    }

    /**
     * Called by the message manager when the user press space on a state which has the fade out effect
     */
    public void NotifyLaunchFadeOut()
    {
        FadeManager.Init(fadeDuration, FadeManager.FADE_OUT, goNextState);
    }

    /**
     * Callback called when the FadeManager has finished the fade out effect
     */
    public void goNextState()
    {
        messageManager.SetHasFadeOut(false);
        messageManager.SetFadeOutScript(null);
        messageManager.GoNextState();
    }
}
