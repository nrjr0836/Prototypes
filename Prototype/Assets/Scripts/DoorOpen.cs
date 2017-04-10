using System;
using UnityEngine;
using TouchScript.Gestures;



public class DoorOpen : MonoBehaviour{

	private void clicked() {
		for (int i = 0; i <= transform.GetSiblingIndex(); i++) {
			print(transform.parent.GetChild(i).name);
		}
	}

	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void tappedHandler(object sender, EventArgs e)
	{
		clicked();
	}
}
