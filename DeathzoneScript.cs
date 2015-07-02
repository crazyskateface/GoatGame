using UnityEngine;
using System.Collections;

public class DeathzoneScript : MonoBehaviour {
	GameObject player;
	GameControl control;
	// Use this for initialization
	void Start () {
		control = GameControl.control;
		GameObject player = GameObject.Find ("goaty2");
	}

	void OnCollision2D(Collision2D other){


		if(other.gameObject == player.gameObject){

			control.health = 0;
			Debug.Log ("nooooo");
		}

	}

}
