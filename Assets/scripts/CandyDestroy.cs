using UnityEngine;
using System.Collections;

public class CandyDestroy : MonoBehaviour {
	public CandyHolder candyHolder;
	public int reward;

	public GameObject effectPrefab;
	public Vector3 effectRotation;

	void OnTriggerEnter(Collider other){
		candyHolder.AddCandy (reward);
		if (other.gameObject.tag == "Candy") {
			Destroy (other.gameObject);

			if (effectPrefab != null) {
				Instantiate (effectPrefab,other.transform.position,Quaternion.Euler(effectRotation));
			}

		}
	}
}
