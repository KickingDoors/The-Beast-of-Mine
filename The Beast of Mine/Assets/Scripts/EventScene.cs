using UnityEngine;
using System.Collections;

public class EventScene : MonoBehaviour {

	public MsgManager MsgManager;

	public int TargetMsg; // Preencher com a mensagem na qual este evento será chamado

	public string NomeDoMetodo;

	public void Update(){

		if (MsgManager.enabled == true) {
			if (MsgManager.curMsg == TargetMsg) {

				BroadcastMessage (NomeDoMetodo);
			}
		}
	}
}
