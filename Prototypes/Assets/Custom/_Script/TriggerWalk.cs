using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWalk : MonoBehaviour {

	public GameObject startAni;
	Animator startAniAnimator;
	Animator animator;

	// Use this for initialization
	void Start () {
		startAniAnimator = startAni.GetComponent<Animator> ();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startAniAnimator.GetBool("Personstand") == true) {
			animator.SetTrigger ("Walk");
		}
	}
}
