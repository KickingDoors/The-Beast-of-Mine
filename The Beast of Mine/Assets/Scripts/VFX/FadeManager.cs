using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    private bool ready = false;
    private bool finished = false;
    private float alphaSpeed;
    private bool isFading = false;
    private GameObject fadeCanvas;
    private Image fadeCanvasImage;
    public const string FADE_IN = "fadeIn";
    public const string FADE_OUT = "fadeOut";

    public void init(GameObject fadeCanvas, float duration, string effect)
    {
        this.isFading = true;
        this.fadeCanvas = fadeCanvas;
        alphaSpeed = 255 / (duration / Time.deltaTime);
        fadeCanvasImage = fadeCanvas.GetComponent<Image>();
        if (effect == FADE_IN)
        {
            alphaSpeed = -alphaSpeed;
            this.changeFadeCanvasAlphaColor(255);
        } else
        {
            this.changeFadeCanvasAlphaColor(0);
        }
        this.fadeCanvas.SetActive(true);
        ready = true;
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
    private void changeFadeCanvasAlphaColor(float val)
    {
        Color color = fadeCanvasImage.color;
        color.a = val / 255.0F;
        fadeCanvasImage.color = color;
    }
	
	void FixedUpdate () {
		if(ready && !finished)
        {
            changeFadeCanvasAlphaColor(fadeCanvasImage.color.a * 255.0F + alphaSpeed);
            finished = fadeCanvasImage.color.a >= 1 || fadeCanvasImage.color.a <= 0;
            if(finished)
            {
                this.fadeCanvas.SetActive(false);
                this.isFading = false;
            }
        }
	}
}
