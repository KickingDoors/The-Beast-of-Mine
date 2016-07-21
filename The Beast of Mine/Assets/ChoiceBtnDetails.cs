using UnityEngine;
using System.Collections;

public class ChoiceBtnDetails : MonoBehaviour {

	public int VarToActivate;

	[SerializeField]
	ActionTracker At;


	public void UpdateActionTracker (){

		if (VarToActivate != 0) {
			At.Variables [VarToActivate] = true;
		}
	}
}