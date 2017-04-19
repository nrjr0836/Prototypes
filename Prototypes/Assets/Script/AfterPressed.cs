using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;

/// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class AfterPressed : MonoBehaviour, IPointerClickHandler {

	public GameObject text;
	private IEnumerator coroutine;

	public void OnPointerClick(PointerEventData eventData) {
		clicked();
	}

	private void clicked()
	{
		print ("adfasdfasdfasdfadf");
		text.SetActive (true);
		coroutine = changeAlpha(3.0f);
		StartCoroutine(coroutine);
	}

	private IEnumerator changeAlpha(float waitTime)
	{
		Color color = text.GetComponent<Text>().color;
		color.a = 255f;
		while (true)
		{
			text.GetComponent<Text>().color = color;
			yield return new WaitForSeconds(waitTime);
			color.a = 0f;
			text.GetComponent<Text>().color = color;
		}
	}
}