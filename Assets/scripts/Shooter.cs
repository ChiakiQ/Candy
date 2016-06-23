using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	const int SphereCandyFrequence = 3;

	const int MaxShotPower = 5;
	const int RecoverySeconds = 3;

	int sampleCandyCount;
	int shotPower = MaxShotPower;
	AudioSource shotSound;

	public GameObject[] candyPrefab;
	public GameObject[] candySquarePrefab;
	public CandyHolder candyHolder;

	public float shotSpeed;
	public float shotTorque;

	public float baseWidth;
	// Use this for initialization
	void Start () {
		shotSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1"))
			Shot ();
	}
	GameObject SampleCandy(){
		GameObject prefab = null;
		if (sampleCandyCount % SphereCandyFrequence == 0) {
			int index = Random.Range (0, candyPrefab.Length);
			prefab = candyPrefab [index];
		} else {
			int index = Random.Range (0, candySquarePrefab.Length);
			prefab = candySquarePrefab [index];
		}

		sampleCandyCount++;
		return prefab;
	}
	Vector3 GetInstantiatePosition(){
		float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
		return transform.position + new Vector3 (x, 0, 0);
	}
	public void Shot (){
		if (candyHolder.GetCandyAmount () <= 0 || shotPower <= 0) {
			return;
		}
		GameObject candy = (GameObject)Instantiate (SampleCandy(), GetInstantiatePosition(), Quaternion.identity);
		candy.transform.parent = candyHolder.transform;

		Rigidbody candyRigidBody = candy.GetComponent<Rigidbody> ();
		candyRigidBody.AddForce (transform.forward * shotSpeed);
		candyRigidBody.AddTorque (new Vector3 (0, shotTorque, 0));
		candyHolder.CosumeCandy ();
		CosumePower ();
		shotSound.Play ();
	} 
	void OnGUI	(){
		GUI.color = Color.black;
		string label = "";
		for(int i = 0; i < shotPower ; i++){
			label = label + "+";
		}
		GUI.Label (new Rect (0, 30, 100, 30), label);
	}
	void CosumePower (){
		shotPower--;
		StartCoroutine (RecoverPower());
	}
	IEnumerator RecoverPower (){
		yield return new WaitForSeconds (RecoverySeconds);
		shotPower++;
	}
}
