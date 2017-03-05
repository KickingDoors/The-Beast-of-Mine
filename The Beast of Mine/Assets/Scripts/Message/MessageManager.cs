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
    private const string ONE_QUARTER_ALPHA = "40";
    private const string HALF_ALPHA = "7F";
    private const string THREE_QUARTER_ALPHA = "BF";
    private const string FULL_ALPHA = "FF";
    private const string WHITE = "ffffff";

    [SerializeField]
	private Animator TextAnim;
    public float letterDelay = 0.1f;
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
        StartCoroutine(WriteMsg());
	}

	IEnumerator WriteMsg (){
        TextAnim.SetBool("visible", true);
        foreach (Char letter in CurrentMessage)
        {
            updateTextTransparency();
            DisplayingMsg += "<color=#"+WHITE+ONE_QUARTER_ALPHA+">" + letter+"</color>"; // set transparency to 25%
            MainText.text = DisplayingMsg;
            yield return new WaitForSeconds(letterDelay);
        }
        for(int i = 0; i < 3; i++) // treat the last letter
        {
            updateTextTransparency();
            MainText.text = DisplayingMsg;
            yield return new WaitForSeconds(letterDelay);
        }
    }

    private void updateTextTransparency()
    {
        DisplayingMsg = DisplayingMsg
            .Replace(WHITE + THREE_QUARTER_ALPHA, WHITE + FULL_ALPHA) // 75% to 100%
            .Replace(WHITE + HALF_ALPHA, WHITE + THREE_QUARTER_ALPHA) // 50% to 75%
            .Replace(WHITE + ONE_QUARTER_ALPHA, WHITE + HALF_ALPHA) // 25% to 50%
        ;
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
