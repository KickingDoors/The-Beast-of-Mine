using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela06_Trigger : StateMachineBehaviour {


    void OnStateEnter()
    {
        GameObject.Find("tela5").GetComponent<Animator>().SetTrigger("Avermelhado");
	}
}
