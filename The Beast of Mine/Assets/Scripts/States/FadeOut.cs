using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class FadeOut : StateMachineBehaviour
{

    public float fadeDuration = 1;
    // required bool for botoes states using fade out as it is launched per update
    private bool hasInitiated = false;

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
        if(!hasInitiated) // check that we didn't already init (useful for botoes states as explained in var declaration)
        {
            FadeManager.Init(fadeDuration, FadeManager.FADE_OUT, goNextState);
            hasInitiated = true;
        }
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
