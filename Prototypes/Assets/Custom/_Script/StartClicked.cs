using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;



public class StartClicked : MonoBehaviour, IPointerClickHandler{
	public string name;
	public GameObject EnableDoors;


	public void OnPointerClick(PointerEventData eventData) {
		clicked();
	}

	public void OnMouseDown() {
		clicked();
	}

	private void clicked() {
		this.gameObject.SetActive (false);
		EnableDoors.SetActive (true);
	}
}
