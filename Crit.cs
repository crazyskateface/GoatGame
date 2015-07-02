using UnityEngine;
using System.Collections;

public class Crit : MonoBehaviour {
	


	private bool triggered = false;
	// Use this for initialization
	void Start () {

	}
	
	
	void OnTriggerEnter2D(Collider2D other){
		if(!triggered){
			triggered = true;
			addScore ();
			other.SendMessage ("plustenSpawn");
			//Debug.Log ("Add critter score: " +control.score.ToString ());
			GetComponent<AudioSource>().Play ();
			//gameObject.AddComponent<Rigidbody2D>();
			Rigidbody2D parentRigid = gameObject.GetComponentInParent<Rigidbody2D>();
			parentRigid.gravityScale = 2.0f;
			parentRigid.AddForce (new Vector2(0f,200.0f));

			Destroy (gameObject, 2.0f);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void addScore(){
		//control.score += 10;
		GameObject.Find ("GameControl").SendMessage ("AddScore");

	}
}
