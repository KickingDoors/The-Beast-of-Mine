using UnityEngine;
using System.Collections;

public class StopTimer : StateMachineBehaviour {
	void OnStateEnter(){

		GameObject.Find ("GameManager").GetComponent<TimeManager> ().StopTimer ();
	}
}
