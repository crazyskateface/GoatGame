using UnityEngine;
using System.Collections;

public class worldUI : MonoBehaviour {

	public GameObject plusten;
	float timer;
	// Use this for initialization
	void Start () {
		GetComponent<UnityEngine.UI.Image> ().color = Color.white; // get color component to fuck wit
		timer = Time.time+2;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer < Time.time){
			GetComponent<UnityEngine.UI.Image> ().color = Color.clear;
			//Destroy (gameObject, 2f);
		}



	}

	void ShowWorldUI(){

		//col = Color.white;

	}
}





















