using System;
using UnityEngine;
using TouchScript.Gestures;
using UnityEngine.UI;

public class DoorDragged : MonoBehaviour
{
	private Transform parentToReturnTo = null;
	private GameObject placeholder = null;
	private Transform cachedTransform;

	private void Awake()
	{
		cachedTransform = transform;
	}

	private void OnEnable()
	{
		GetComponent<TransformGesture>().TransformStarted += transformStartedHandler;
		GetComponent<TransformGesture>().Transformed += transformedHandler;
		GetComponent<TransformGesture>().TransformCompleted += transformCompletedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TransformGesture>().TransformStarted -= transformStartedHandler;
		GetComponent<TransformGesture>().Transformed -= transformedHandler;
		GetComponent<TransformGesture>().TransformCompleted -= transformCompletedHandler;
	}

	private void transformStartedHandler(object sender, EventArgs e)
	{
		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
//		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
//		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
//		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
//		le.flexibleWidth = 0;
//		le.flexibleHeight = 0;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		parentToReturnTo = this.transform.parent;
		transform.SetParent (this.transform.parent.parent);

		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}

	private void transformedHandler(object sender, EventArgs e)
	{
		var gesture = sender as ITransformGesture;
		gesture.ApplyTransform(cachedTransform);
//		print (transform.position);
//		this.transform.position = eventData.position;
		int newSiblingIndex = parentToReturnTo.childCount;

		for (int i = 0; i<parentToReturnTo.childCount; i++){
			if (transform.position.x < parentToReturnTo.GetChild(i).position.x) {
				newSiblingIndex = i;
				if (placeholder.transform.GetSiblingIndex() < newSiblingIndex) 
					newSiblingIndex--;
				break;
			}
		}
		placeholder.transform.SetSiblingIndex(newSiblingIndex);
	}
	private void transformCompletedHandler(object sender, EventArgs e)
	{
		transform.SetParent(parentToReturnTo);
		transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		Destroy (placeholder);
	}
}
