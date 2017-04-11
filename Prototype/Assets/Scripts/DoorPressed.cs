using System;
using UnityEngine;
using TouchScript.Gestures;
using Random = UnityEngine.Random;
using UnityEngine.UI;

/// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class DoorPressed : MonoBehaviour {

	private Quaternion originRotation;
	public float shake_intensity = .3f;

	void Start() {
		originRotation = transform.rotation;
	}
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
		GameManager.instance.act(StateMachine.GameInput.LongPress);
		originRotation = transform.rotation;
		this.transform.parent.parent.GetComponent<Image> ().raycastTarget = false;
	}

	void Update (){
		if (GameManager.instance.getCurrentState ().Equals (StateMachine.GameState.DoorReordering)) {
			transform.rotation = new Quaternion (
				originRotation.x + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.y + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.z + Random.Range (-shake_intensity, shake_intensity) * .2f,
				originRotation.w + Random.Range (-shake_intensity, shake_intensity) * .2f
			);
		} else {
			transform.rotation = originRotation;
		}
	}
}