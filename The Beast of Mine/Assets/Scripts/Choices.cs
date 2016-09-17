using UnityEngine;
using UnityEngine.UI;
using SmartLocalization;
using System.Collections;

public class Choices : MonoBehaviour {

    [Header("References")]
	public GameObject ChoicesObj;
	public Button[] ChoiceBtns;
	public Text[] ChoicesText;

    [Header("Things To Setup")]
    public int AmmountOfOptions = 4;
    public MsgManager[] ChoiceConsequences;
    public string[] ChoicesNames;
    public string[] VarsToActivate;
    public bool[] StopsTimer;

	void Start () {

		ChoicesObj.SetActive (true);

		for (int i = AmmountOfOptions; i < 4; i++) {

			ChoiceBtns [i].gameObject.SetActive (false);
		}

		for (int i = 0; i < AmmountOfOptions; i++) {

			ChoiceBtns [i].onClick.RemoveAllListeners ();
		}
		if (AmmountOfOptions > 0) {
			ChoiceBtns [0].onClick.AddListener (() => ChooseBtn (0));
			ChoicesText [0].text = LanguageManager.Instance.GetTextValue(ChoicesNames [0]);
            ChoiceBtns [0].GetComponent<ChoiceBtnDetails> ().VarToActivate = VarsToActivate[0];
            ChoiceBtns[0].GetComponent<ChoiceBtnDetails>().ShouldStopTimer = StopsTimer[0];
        }

		if(AmmountOfOptions > 1 ){
			ChoiceBtns [1].onClick.AddListener (() => ChooseBtn (1));
			ChoicesText [1].text = LanguageManager.Instance.GetTextValue(ChoicesNames[1]);
			ChoiceBtns [1].GetComponent<ChoiceBtnDetails> ().VarToActivate = VarsToActivate[1];
            ChoiceBtns[1].GetComponent<ChoiceBtnDetails>().ShouldStopTimer = StopsTimer[1];
        }

		if(AmmountOfOptions > 2 ){
			ChoiceBtns [2].onClick.AddListener (() => ChooseBtn (2));
			ChoicesText [2].text = LanguageManager.Instance.GetTextValue(ChoicesNames[2]);
			ChoiceBtns [2].GetComponent<ChoiceBtnDetails> ().VarToActivate = VarsToActivate[2];
            ChoiceBtns[2].GetComponent<ChoiceBtnDetails>().ShouldStopTimer = StopsTimer[2];
        }

		if(AmmountOfOptions > 3 ){
			ChoiceBtns [3].onClick.AddListener (() => ChooseBtn (3));
			ChoicesText [3].text = LanguageManager.Instance.GetTextValue(ChoicesNames[3]);
			ChoiceBtns [3].GetComponent<ChoiceBtnDetails> ().VarToActivate = VarsToActivate[3];
            ChoiceBtns[3].GetComponent<ChoiceBtnDetails>().ShouldStopTimer = StopsTimer[3];
        }
	}

	public void ChooseBtn ( int TargetID ){

		ChoiceConsequences[TargetID].enabled = true;

		ChoiceBtns [TargetID].GetComponent<ChoiceBtnDetails> ().UpdateActionTracker ();

		for (int i = 0; i < 4; i++) {

			ChoiceBtns [i].gameObject.SetActive (true);
		}

		ChoicesObj.SetActive (false);

		this.enabled = false;
	}
}