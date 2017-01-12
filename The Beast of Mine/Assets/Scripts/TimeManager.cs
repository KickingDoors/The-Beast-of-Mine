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
		if (ConsequenceID == 1) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
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