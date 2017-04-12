using UnityEngine;
using System.Collections;


public class Back : MonoBehaviour {


	public GameObject DisableScene;
	public GameObject EnableBack;


	void OnMouseDown(){
		DisableScene.SetActive (false);
		EnableBack.SetActive (true);
	}
}
