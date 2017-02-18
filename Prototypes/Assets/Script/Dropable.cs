using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Dropable : MonoBehaviour, IDropHandler {

	public void OnDrop(PointerEventData eventData){
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			d.parentToReturnTo = this.transform;
		}

	}

}
