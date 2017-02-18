using System;
using TouchScript.Gestures;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	private TapGesture tapGesture;
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
		print("adfasdfasdfasdfasdf");
	}
}
