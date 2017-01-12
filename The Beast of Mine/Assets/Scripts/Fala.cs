using UnityEngine;
using SmartLocalization;

public class Fala : StateMachineBehaviour
{

	[Header("Conteudo")]
	public string MensagemID;

	[Header("Visual")]
	public Sprite BackgrundImage;
	void OnStateEnter(){
        Animator animator = GameObject.Find("GameManager").GetComponent<Animator>();
        animator.ResetTrigger ("Resposta1");
        animator.ResetTrigger ("Resposta2");
        animator.ResetTrigger ("PassMessage");
		MessageManager MM = GameObject.Find ("GameManager").GetComponent<MessageManager> ();

		MM.WriteMessage (LanguageManager.Instance.GetTextValue(MensagemID).ToCharArray());
		if(BackgrundImage != null)
			MM.ShowImage (BackgrundImage);
	}
}
