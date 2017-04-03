using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;



public class DoorOpen : MonoBehaviour, IPointerClickHandler{
	public string name;
	public GameObject DisableDoors;
	public GameObject EnableDoors;


	public void OnPointerClick(PointerEventData eventData) {
		clicked();
	}

	private void clicked() {
		for (int i = 0; i <= this.transform.GetSiblingIndex(); i++) {
			print (this.transform.parent.GetChild (i).GetInstanceID());
		}
			
		DisableDoors.SetActive (false);
		EnableDoors.SetActive (true);

	}
}
