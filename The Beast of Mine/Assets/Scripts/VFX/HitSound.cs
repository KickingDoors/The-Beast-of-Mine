using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour {

	public AudioSource _AS;

	public void Hit(){

		_AS.clip = Resources.Load<AudioClip> ("Sounds/Dor " + Random.Range(1,4)) as AudioClip;
		_AS.Play ();
	}
}
