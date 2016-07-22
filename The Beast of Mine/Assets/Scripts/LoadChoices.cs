using UnityEngine;
using System.Collections;

public class LoadChoices : MonoBehaviour {

	public Choices TargetChoicesNoAction, TargetChoicesWithAction;
	public int ActionID;

	public void OpenChoices(){

		if (ActionID != 0) {
			if (GameObject.Find ("GameManager").GetComponent<ActionTracker> ().Variables [ActionID] == false) {

				TargetChoicesNoAction.enabled = true;

			} else {

				TargetChoicesWithAction.enabled = true;
			}
		} else {
			TargetChoicesNoAction.enabled = true;
		}
	}
}