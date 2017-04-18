using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

	public GameObject otherObject;
	Animator otherAnimator;
	public GameObject walkObject;
	Animator walkAnimator;

	// Use this for initialization
	void Start () {
		otherAnimator = otherObject.GetComponent<Animator> ();
		walkAnimator = walkObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Col")
		{
			otherAnimator.SetTrigger ("Personstand");
			walkAnimator.SetTrigger("Walk");
			Destroy(gameObject);
		}
	}
}
