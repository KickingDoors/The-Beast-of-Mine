using UnityEngine;
using System.Collections;

public class CheckPoint : StateMachineBehaviour {

	public string CheckPointName;

	void OnStateEnter(){

		GameObject.Find ("GameManager").GetComponent<MessageManager> ().SaveCheckPoint (CheckPointName);
	}
}
