using UnityEngine;
using System.Collections;

public class ChickenScript : MonoBehaviour {


	//GameControl control;
	// Use this for initialization
	void Start () {
		//control = GameControl.control;
	}


	void OnTriggerEnter2D(Collider2D other){
		
		Debug.Log ("Trigger entered");
		//control.levelTime += 30.0f;
		GameObject.Find ("GameControl").SendMessage ("addTime");
		Destroy (gameObject);
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
