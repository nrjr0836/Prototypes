using System;
using UnityEngine;
using TouchScript.Gestures;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;

/// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class AfterPressed : MonoBehaviour {

	public GameObject text;
	private IEnumerator coroutine;

	private void OnEnable()
	{
		GetComponent<LongPressGesture>().LongPressed += longPressedHandler;
	}

	private void OnDisable()
	{
		GetComponent<LongPressGesture>().LongPressed -= longPressedHandler;
	}

	private void longPressedHandler(object sender, EventArgs e)
	{
		print ("adfasdfasdfasdfadf");
		text.SetActive (true);
		coroutine = changeAlpha(5.0f);
		StartCoroutine(coroutine);
	}

	private IEnumerator changeAlpha(float waitTime)
	{
		Color color = GetComponent<Text> ().color;
		color.a = 255f;
		while (true)
		{
			GetComponent<Text> ().color = color;
			yield return new WaitForSeconds(waitTime);
			color.a = 0f;
			GetComponent<Text> ().color = color;
		}
	}
}