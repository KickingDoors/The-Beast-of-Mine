using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SmartLocalization;
using System;

public class MessageManager : MonoBehaviour {

	public Animator Anim;
	public bool CanPassMsg;
	public Text MainText;
	public Image BackGround;
	public string SavedCheckPoint;
    
	[SerializeField]
	private Animator TextAnim;

	public char[] CurrentMessage;
	public string DisplayingMsg;

    private FadeOut fadeOutScript;
    private bool hasFadeOut;

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


		TextAnim.SetBool ("visible", true);

		for (int i = 0; i < CurrentMessage.Length; i++) {

			//yield return null;

			DisplayingMsg += CurrentMessage [i];
			MainText.text = DisplayingMsg;
		}

		yield return null;
	}

	// Update is called once per frame
	void Update () {
		if ((CanPassMsg == true && Input.GetKeyDown(KeyCode.Space)) // fala and space
            || Anim.GetBool("Resposta1") // botoes and answer 1
            || Anim.GetBool("Resposta2")) { // botoes and answer2
                if(hasFadeOut)
                {
                    fadeOutScript.NotifyLaunchFadeOut();
					TextAnim.SetBool ("visible", false);
                } else
                {
					TextAnim.SetBool ("visible", false);
					StartCoroutine ("WaitAndPassMsg");
                    //GoNextState();
                }
		}
	}

    public void SetHasFadeOut(bool hasFO)
    {
        hasFadeOut = hasFO;
    }

    public void SetFadeOutScript(FadeOut script)
    {
        fadeOutScript = script;
    }

	public void ShowImage (Sprite sprite){

		BackGround.sprite = sprite;
	}

    public void GoNextState()
    {
		Anim.SetTrigger("PassMessage");
    }

	IEnumerator WaitAndPassMsg(){

		yield return new WaitForSeconds (0.5f);
		Anim.SetTrigger("PassMessage");
	}
}
