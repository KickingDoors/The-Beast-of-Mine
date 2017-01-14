using UnityEngine;
using System.Collections;

public class StartTimer : StateMachineBehaviour {

	public float Duration;
	public int ConsequenceID;
	void OnStateEnter(){
		GameObject.Find ("GameManager").GetComponent<TimeManager> ().StartTimer(Duration, ConsequenceID);
	}
}
