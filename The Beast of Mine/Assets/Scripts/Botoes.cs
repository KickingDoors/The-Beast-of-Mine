using UnityEngine;
using SmartLocalization;
using UnityEngine.UI;
using System.Collections;

public class Botoes : StateMachineBehaviour {

	[Header("Conteudo")]
	public string MensagemID;
	public string[] RespostaID;
	public bool DeveFecharBotoes = true;

	[Header("Visual")]
	public Sprite BackgrundImage;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	void OnStateEnter(){

		GameObject.Find ("GameManager").GetComponent<Animator> ().ResetTrigger ("Resposta1");
		GameObject.Find ("GameManager").GetComponent<Animator> ().ResetTrigger ("Resposta2");
		GameObject.Find ("GameManager").GetComponent<Animator> ().ResetTrigger ("PassMessage");

		MessageManager MM = GameObject.Find ("GameManager").GetComponent<MessageManager> ();

		MM.CanPassMsg = false;
		MM.WriteMessage (LanguageManager.Instance.GetTextValue(MensagemID).ToCharArray ());
		if (BackgrundImage != null)
			MM.ShowImage (BackgrundImage);

		for (int i = 0; i < RespostaID.Length; i++) {

			GameObject.Find ("Btn" + (i + 1)).GetComponent<LayoutElement> ().ignoreLayout = false;
			GameObject.Find ("Btn" + (i + 1)).GetComponent<Image> ().enabled = true;
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

			GameObject.Find ("GameManager").GetComponent<MessageManager> ().CanPassMsg = true;
		}
	}
}