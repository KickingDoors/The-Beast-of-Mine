﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Choices : MonoBehaviour {

	public GameObject ChoicesObj;

	public Button[] ChoiceBtns;

	public int AmmountOfOptions = 4;

	public MsgManager[] ChoiceConsequences;

	public string[] ChoicesNames;
	public Text[] ChoicesText;

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
			ChoicesText [0].text = ChoicesNames [0];
		}

		if(AmmountOfOptions > 1 ){
			ChoiceBtns [1].onClick.AddListener (() => ChooseBtn (1));
			ChoicesText [1].text = ChoicesNames [1];
		}

		if(AmmountOfOptions > 2 ){
			ChoiceBtns [2].onClick.AddListener (() => ChooseBtn (2));
			ChoicesText [2].text = ChoicesNames [2];
		}

		if(AmmountOfOptions > 3 ){
			ChoiceBtns [3].onClick.AddListener (() => ChooseBtn (3));
			ChoicesText [3].text = ChoicesNames [3];
		}
	}

	public void ChooseBtn ( int TargetID ){

		ChoiceConsequences[TargetID].enabled = true;

		for (int i = 0; i < 4; i++) {

			ChoiceBtns [i].gameObject.SetActive (true);
		}

		ChoicesObj.SetActive (false);

		this.enabled = false;
	}
}