using UnityEngine;
using System.Collections;

public class AutoDestroyEffect : MonoBehaviour {
	ParticleSystem partical;
	// Use this for initialization
	void Start () {
		partical = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (partical.isPlaying == false) {
			Destroy (gameObject);
		}
	}
}
