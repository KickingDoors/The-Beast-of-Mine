using UnityEngine;
using SmartLocalization;
using UnityEngine.UI;


public class Botoes : StateMachineBehaviour {

	[Header("Conteudo")]
	public string MensagemID;
	public string[] RespostaID;
    public string correctAnswerId;
    public bool DeveFecharBotoes = true;

    [Header("Visual")]
    public string specificEffect;

    private MessageManager MM;
    void OnStateEnter() {
        GameObject.Find("GameManager").GetComponent<VFXManager>().handleEffect(specificEffect);
        // we register the correct answer id
        GameObject.Find("GameManager").GetComponent<AnswerCounter>().updatePreviousCorrectAnswer(correctAnswerId, RespostaID);
        Animator animator = GameObject.Find("GameManager").GetComponent<Animator>();
        animator.ResetTrigger("Resposta1");
        animator.ResetTrigger ("Resposta2");
        animator.ResetTrigger ("PassMessage");
		MM = GameObject.Find ("GameManager").GetComponent<MessageManager> ();
		MM.CanPassMsg = false;
		MM.WriteMessage (LanguageManager.Instance.GetTextValue(MensagemID).ToCharArray ());
		for (int i = 0; i < RespostaID.Length; i++) {
			GameObject.Find ("Btn" + (i + 1)).GetComponent<LayoutElement> ().ignoreLayout = false;
			//GameObject.Find ("Btn" + (i + 1)).GetComponent<Image> ().enabled = true;
			GameObject.Find ("Btn" + (i + 1) + "_Text").GetComponent<Text> ().enabled = true;
			GameObject.Find ("Btn" + (i + 1) + "_Text").GetComponent<Text> ().text = LanguageManager.Instance.GetTextValue(RespostaID [i]);
		}
	}

    void OnStateExit(){
        if (DeveFecharBotoes == true) {
			for (int i = 0; i < RespostaID.Length; i++) {
				GameObject.Find ("Btn" + (i + 1)).GetComponent<LayoutElement> ().ignoreLayout = true;
				GameObject.Find ("Btn" + (i + 1)).GetComponent<Image> ().enabled = false;
				GameObject.Find ("Btn" + (i + 1) + "_Text").GetComponent<Text> ().enabled = false;
			}
            MM.CanPassMsg = true;
		}
    }
}
