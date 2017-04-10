using UnityEngine;
using System.Collections;

public class Apperance : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		GetComponent<Rigidbody> ().velocity = 3 * Vector3.right;


}
	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Capsule") {
			Debug.Log ("hit");
			GetComponent<Rigidbody> ().velocity = 2 * Vector3.zero;
		}
	}

}