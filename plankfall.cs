using UnityEngine;
using System.Collections;

public class plankfall : MonoBehaviour {

	GameObject player;
	public float gravity = 2.0f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("goaty2");
	}


	void OnCollision2DEnter(Collider2D other){
		if (other.gameObject == player) {
			GetComponent<Rigidbody2D>().gravityScale = gravity;

		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
