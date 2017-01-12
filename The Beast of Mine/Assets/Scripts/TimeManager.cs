using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeManager : MonoBehaviour {

	public IEnumerator Timer( float Duration , int ConsequenceID ){

		// ID List :
		// 1 - Death
		for (float i = Duration; i > 0; i -= 0.1f) {
			yield return new WaitForSeconds (0.1f);
			/*print (i);*/
		}
        // inc bad answers by 1 if the timer ends
        GameObject.Find("GameManager").GetComponent<AnswerCounter>().updateBadAnswersNumber(1);
		if (ConsequenceID == 1) {
            SceneReloader.loadScene(SceneManager.GetActiveScene().name);
		} else if (ConsequenceID == 2) {

			GetComponent<Animator> ().SetTrigger ("EndedTimer");
		}
	}

	public void StartTimer( float Duration, int ConsequenceID ){

		StartCoroutine (Timer (Duration, ConsequenceID));
	}

	public void StopTimer (){

		StopAllCoroutines ();
	}
}
