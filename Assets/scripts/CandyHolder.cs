using UnityEngine;
using System.Collections;

public class CandyHolder : MonoBehaviour {

	const int DefaultCandyAmount = 30;
	const int second = 10;
	int candy = DefaultCandyAmount;

	int counter;

	public int GetCandyAmount (){
		return candy;
	}

	public void AddCandy(int amount){
		candy += amount;
	}
	public void CosumeCandy (){
		if (candy > 0) {
			candy--;
		}
	}

	void OnGUI (){
		GUI.color = Color.black;

		string label = "Candy : " + candy;

		if (counter > 0) {
			label = label + " (" + counter + ")";
		}

		GUI.Label (new Rect (0, 0, 100, 30), label);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (candy < DefaultCandyAmount && counter <= 0) {
			StartCoroutine (RecoveryCandy());
		}
	}

	IEnumerator RecoveryCandy (){
		counter = second;
		while (counter > 0) {
			yield return new WaitForSeconds (1.0f);
			counter--;
		}
		candy++;
	}
}
