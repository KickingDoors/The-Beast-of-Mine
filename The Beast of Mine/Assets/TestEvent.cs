using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestEvent : MonoBehaviour {



	public void EnableImage(){

		GetComponent<Image> ().color = Color.white;
	}
}
