using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFX : StateMachineBehaviour {

    [SerializeField]
    private int Health;
    [SerializeField]
    private bool isHit = true;

    void OnStateEnter()
    {
        Animator anim = GameObject.Find("Hit VFX").GetComponent<Animator>();
        anim.SetInteger("Health", Health);
        if(isHit)
            anim.SetTrigger("Hit");
    }
}
