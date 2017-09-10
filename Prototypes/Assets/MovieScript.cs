using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]

public class MovieScript : MonoBehaviour {


	public MovieTexture movieclips;

	private MeshRenderer meshRenderer;


	void Start(){
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material.mainTexture = movieclips;

		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();

		movieclips.Play ();
		movieclips.loop = true;
	}

}