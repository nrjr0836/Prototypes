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
		int idx = this.transform.GetSiblingIndex ();
		DisableDoors.SetActive (false);
		EnableDoors.SetActive (true);
		if (idx > 0 && this.transform.parent.GetChild (idx - 1).transform.GetComponent<DoorOpen>().name.Equals("5")) {
			EnableDoors.transform.GetChild (0).transform.GetChild (3).gameObject.SetActive (true);
		}
	}
}
