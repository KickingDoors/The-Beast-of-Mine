using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;

public class MessageManager : MonoBehaviour {

	public Animator Anim;
	public bool CanPassMsg;
	public Text MainText;
	public Image BackGround;
	public string SavedCheckPoint;

	public char[] CurrentMessage;
	public string DisplayingMsg;

	void Start(){

		LanguageManager.Instance.ChangeLanguage ("pt-BR");

		StartCoroutine ("WriteMsg");

		SavedCheckPoint = PlayerPrefs.GetString ("CheckPoint");

		if (SavedCheckPoint != null) {

			GetComponent<Animator> ().Play (SavedCheckPoint);
		}
	}

	public void SaveCheckPoint(string CheckPointName){

		SavedCheckPoint = CheckPointName;
		PlayerPrefs.SetString ("CheckPoint" , SavedCheckPoint);
		PlayerPrefs.Save();
	}

	public void WriteMessage(char[] Msg){

		DisplayingMsg = "";
		StopAllCoroutines ();
		CurrentMessage = Msg;
		StartCoroutine ("WriteMsg");
	}

	IEnumerator WriteMsg (){

		for (int i = 0; i < CurrentMessage.Length; i++) {

			yield return null;
			yield return null;

			DisplayingMsg += CurrentMessage [i];
			MainText.text = DisplayingMsg;
		}
		yield return null;
	}

	// Update is called once per frame
	void Update () {

		if (CanPassMsg == true) {
			if (Input.GetKeyDown (KeyCode.Space)) {

				Anim.SetTrigger ("PassMessage");
			}
		}
	}

	public void ShowImage (Sprite sprite){

		BackGround.sprite = sprite;
	}
}