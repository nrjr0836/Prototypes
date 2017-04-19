using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

	public GameObject otherObject;
	public GameObject before;
	public GameObject after;
	Animator otherAnimator;

	// Use this for initialization
	void Start () {
		otherAnimator = otherObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Col")
		{
			otherAnimator.SetBool ("Personstand", true);
			before.SetActive (false);
			after.SetActive (true);
			Destroy(gameObject);
		}
	}
}
