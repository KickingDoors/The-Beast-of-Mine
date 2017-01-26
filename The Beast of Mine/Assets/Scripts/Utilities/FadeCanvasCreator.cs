using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasCreator : MonoBehaviour {

	public GameObject createFadeCanvas(){
        return (GameObject)Instantiate(Resources.Load("prefabs/Fade/FadeCanvas"));
    }
}
