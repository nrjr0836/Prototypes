using System;
using UnityEngine;
using TouchScript.Gestures;
using Random = UnityEngine.Random;

/// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class DoorPressed : MonoBehaviour {

	private Vector3 originPosition;
	private Quaternion originRotation;
	public float shake_decay = 0.00f;
	public float shake_intensity = .3f;

	private float temp_shake_intensity = 0;

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
		Shake();
	}

	void Update (){
		if (temp_shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.y + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.z + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f,
				originRotation.w + Random.Range (-temp_shake_intensity,temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;
		}
	}

	void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		temp_shake_intensity = shake_intensity;

	}
}