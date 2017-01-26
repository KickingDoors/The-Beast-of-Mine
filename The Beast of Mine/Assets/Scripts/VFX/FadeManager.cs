using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    private static bool ready = false;
    private bool finished = false;
    private static float alphaSpeed;
    private static GameObject fadeCanvas;
    private static Image fadeCanvasImage;
    public const string FADE_IN = "fadeIn";
    public const string FADE_OUT = "fadeOut";
    private static Action callback;
    private float deltaTimeCounter = 0;
    private static string effect;
    private static float duration;

    public static void Init(float durationTmp, string effectTmp, Action callbackTmp = null)
    {
        duration = durationTmp;
        effect = effectTmp;
        callback = callbackTmp;
        // if canvas was not instantiated yet, we do it here and we attach the fade manager to it
        if(!fadeCanvas)
        {
            fadeCanvas = (GameObject)Instantiate(Resources.Load("prefabs/Fade/FadeCanvas"));
            fadeCanvas.AddComponent<FadeManager>();
        }
        fadeCanvasImage = fadeCanvas.GetComponent<Image>();
        // set the begin color of the canvas according to the fade effect we want
        if (effectTmp == FADE_IN)
        {
            ChangeFadeCanvasAlphaColor(255);
        } else
        {
            ChangeFadeCanvasAlphaColor(0);
        }
        // display the fadeCanvas
        fadeCanvas.SetActive(true);
        // set to ready so that we can enter into FixedUpdate
        ready = true;
    }
	
	void FixedUpdate () {
		if(ready && !finished)
        {
            deltaTimeCounter += Time.deltaTime;
            ChangeFadeCanvasAlphaColor(GetNewColor());
            finished = deltaTimeCounter >= duration;
            if(finished)
            {
                StopFade();
                if(callback != null)
                {
                    callback();
                    callback = null;
                }
            }
        }
	}

    /**
     * Change the alpha color of the fade canvas
     */
    private static void ChangeFadeCanvasAlphaColor(float val)
    {
        Color color = fadeCanvasImage.color;
        color.a = val / 255.0F;
        fadeCanvasImage.color = color;
    }

    /**
     * Return the computed next alpha color of the canvas based on the accumulated delta time and the duration of the fade effect
     */
    private float GetColorVariation()
    {
        return (deltaTimeCounter / duration * 255);
    }

    /**
     * Get the new alpha color of the canvas according to the fade effect
     */
    private float GetNewColor()
    {
        float colorVariation = GetColorVariation();
        return effect == FADE_IN ? 255.0F - colorVariation : colorVariation;
    }

    /**
     * Reset all the values for the next time and hide the canvas
     */
    public void StopFade()
    {
        fadeCanvas.SetActive(false);
        ready = false;
        finished = false;
        deltaTimeCounter = 0;
    }
}
