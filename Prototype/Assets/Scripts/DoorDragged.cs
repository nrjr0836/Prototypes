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
		if (!(GameManager.instance.getCurrentState().Equals(StateMachine.GameState.DoorReordering)))
			return;
		placeholder = Instantiate (this.gameObject, this.transform.parent);
		Color temp = placeholder.GetComponent<Image> ().color;
		temp.a = 0f;
		placeholder.GetComponent<Image> ().color = temp;

		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex ());

		parentToReturnTo = this.transform.parent;
		transform.SetParent (this.transform.parent.parent);
//		GetComponent<CanvasGroup> ().blocksRaycasts = true;

	}

	private void transformedHandler(object sender, EventArgs e)
	{
		if (!(GameManager.instance.getCurrentState().Equals(StateMachine.GameState.DoorReordering)))
			return;
		var gesture = sender as ITransformGesture;
		gesture.ApplyTransform(cachedTransform);
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
		if (!(GameManager.instance.getCurrentState().Equals(StateMachine.GameState.DoorReordering)))
			return;
		transform.SetParent(parentToReturnTo);
		transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
		GameManager.instance.act(StateMachine.GameInput.LongPressRelease);
		Destroy (placeholder);
		this.transform.parent.parent.GetComponent<Image> ().raycastTarget = true;
	}
}
