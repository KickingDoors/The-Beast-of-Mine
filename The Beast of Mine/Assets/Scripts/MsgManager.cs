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
	public Sprite[] ImagensDeFundo; // As imagens que serão mostrados no fundo em ordem de mensagem, para repetir a imagem é só usar ela duas vezes seguidas e então não haverá uma transição
	public Image ImagemBG;

	void Start(){
	
		StartCoroutine ("WriteMsg", AllMsgs [curMsg]); // Este código escreve a mensagem inicial.
		UpdateImage (ImagensDeFundo[curMsg]);
	}

	void Update (){
		if (curMsg < AllMsgs.Length - 1) {
			if (Input.GetMouseButtonDown (0)) {
				if (isTextWritten == true) { // caso o texto ja esteja escrito devemos passar para a mensagem seguinte.
					if (curMsg <= AllMsgs.Length) {

						curMsg++;
						StopCoroutine ("TransitionFade");
						StopCoroutine ("WriteMsg");
						UpdateImage (ImagensDeFundo[curMsg]);
						StartCoroutine ("WriteMsg", AllMsgs [curMsg]);
					}
				} else {
					// caso o texto nao esteja escrito ainda, desejamos parar o método de escrita da mensagem e começar um que termina instantaneamente.
					StopCoroutine ("WriteMsg");
					WriteMsgInstantaneous (AllMsgs [curMsg]);
					//curMsg++;
				}
			} 
		} else {
			if (MsgToCallOnEndOfMsgs != "") {
				BroadcastMessage (MsgToCallOnEndOfMsgs);
			}
		}
	}

	public IEnumerator TransitionFade(Sprite TargetImg){

		float duration = 1.0f;

		for (float t = 0.0f; t < duration; t += Time.deltaTime) {
			ImagemBG.color = Color.Lerp( ImagemBG.color , Color.black , t/duration );
			yield return null;
		}

		ImagemBG.sprite = TargetImg;

		for (float t = 0.0f; t < duration; t += Time.deltaTime) {
			ImagemBG.color = Color.Lerp( ImagemBG.color , Color.white , t/duration );
			yield return null;
		}

	}

	public IEnumerator FadeOut(){

		float duration = 1.0f;
		//FadeOut
		for (float t = 0.0f; t > duration; t += Time.deltaTime) {
			ImagemBG.color = Color.Lerp( ImagemBG.color , Color.black , t/duration );
			yield return null;
		}

	}

	public void UpdateImage(Sprite TargetImg){

		if (TargetImg != null) {
			if (ImagemBG.sprite != null) {

				if (ImagemBG.sprite != TargetImg) {

					StartCoroutine ("TransitionFade" , TargetImg);

				}
			
			} else {

				StartCoroutine ("TransitionFade" , TargetImg);
			}
		} else {

			StopCoroutine ("TransitionFade");
			StartCoroutine ("FadeOut");
		}
	}

	public void WriteMsgInstantaneous(string Msg){ // Este escreve instantaneamente.

		msgBox.text = "";

		char[] TempMsg = Msg.ToCharArray ();

		for (int i = 0; i < TempMsg.Length; i++ ) {
			msgBox.text += TempMsg [i];
		}
		isTextWritten = true;

        if (curMsg >= AllMsgs.Length - 1)
        {
            this.enabled = false;
            curMsg = 0;
        }
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

        if (curMsg >= AllMsgs.Length - 1)
        {
            this.enabled = false;
            curMsg = 0;
        }
    }
}