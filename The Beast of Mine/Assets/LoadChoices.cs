using UnityEngine;
using System.Collections;

public class LoadChoices : MonoBehaviour {

	public Choices TargetChoices;

	public void OpenChoices(){

		TargetChoices.enabled = true;
	}
}