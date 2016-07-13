using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MsgManager : MonoBehaviour {

	public int curMsg = 0; // Atual mensagem
	public Text msgBox; // Qual objeto da interface que mostra a msg.
	public bool isTextWritten = false; // Isto é para verificar se o texto ja está escrito ou não.
	public string[] AllMsgs; // Para criar mais falas/mensagens, basta aumentar o numero no editor da unity e escrever as mensagens ali mesmo.
	public string MsgToCallOnEndOfMsgs;

	void Start(){
	
		StartCoroutine ("WriteMsg", AllMsgs [curMsg]); // Este código escreve a mensagem inicial.
	}

	void Update (){
		if (curMsg < AllMsgs.Length - 1) {
			if (Input.GetMouseButtonDown (0)) {
				if (isTextWritten == true) { // caso o texto ja esteja escrito devemos passar para a mensagem seguinte.
					if (curMsg <= AllMsgs.Length) {
					
						curMsg++;
						StartCoroutine ("WriteMsg", AllMsgs [curMsg]);
					} else {
						
						curMsg++;
						StartCoroutine ("WriteMsg", AllMsgs [curMsg]);
					}
				} else {
					// caso o texto nao esteja escrito ainda, desejamos para o método de escrita da mensagem e começar um que termina instantaneamente.
					StopCoroutine ("WriteMsg");
					WriteMsgInstantaneous (AllMsgs [curMsg]);
					//curMsg++;
				}
			} 
		} else {
			if (MsgToCallOnEndOfMsgs != "") {
				BroadcastMessage (MsgToCallOnEndOfMsgs);
				this.enabled = false;
			}
		}
	}

	public void WriteMsgInstantaneous(string Msg){ // Este escreve instantaneamente.

		msgBox.text = "";

		char[] TempMsg = Msg.ToCharArray ();

		for (int i = 0; i < TempMsg.Length; i++ ) {
			msgBox.text += TempMsg [i];
		}
		isTextWritten = true;

	}

	public IEnumerator WriteMsg(string Msg){ // Este escreve aos poucos, letra por letra. 1 letra a cada 2 frames.
	
		isTextWritten = false;
		msgBox.text = "";

		char[] TempMsg = Msg.ToCharArray ();

		for (int i = 0; i < TempMsg.Length; i++ ) {
			msgBox.text += TempMsg [i];
			yield return null;
			yield return null;
		}
		isTextWritten = true;

	}
}