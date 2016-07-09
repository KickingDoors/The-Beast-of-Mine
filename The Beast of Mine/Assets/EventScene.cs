using UnityEngine;
using System.Collections;

public class EventScene : MonoBehaviour {

	MsgManager MsgManager;

	public int TargetMsg; // Preencher com a mensagem na qual este evento será chamado

	public string NomeDoMetodo;

	public void Awake(){

		if(MsgManager == null)
			MsgManager = GameObject.Find ("GameManager").GetComponent<MsgManager> ();
	}

	public void Update(){

		if (MsgManager.curMsg == TargetMsg) {

			BroadcastMessage (NomeDoMetodo);
		}
	}
}
