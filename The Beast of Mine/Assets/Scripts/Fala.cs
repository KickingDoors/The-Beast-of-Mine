using UnityEngine;
using SmartLocalization;

public class Fala : StateMachineBehaviour
{

	[Header("Conteudo")]
	public string MensagemID;

	[Header("Visual")]
    public string specificEffect;
    void OnStateEnter(){
        GameObject.Find("GameManager").GetComponent<VFXManager>().handleEffect(specificEffect);
        Animator animator = GameObject.Find("GameManager").GetComponent<Animator>();
        animator.ResetTrigger ("Resposta1");
        animator.ResetTrigger ("Resposta2");
        animator.ResetTrigger ("PassMessage");
		MessageManager MM = GameObject.Find ("GameManager").GetComponent<MessageManager> ();
        MM.WriteMessage (LanguageManager.Instance.GetTextValue(MensagemID).ToCharArray());
		/*if(BackgrundImage != null)
			MM.ShowImage (BackgrundImage);*/
	}
}
