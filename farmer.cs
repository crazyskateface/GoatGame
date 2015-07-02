using UnityEngine;
using System.Collections;

public class farmer : MonoBehaviour {

	GameObject player;
	bool facingRight = false;



	// Use this for initialization
	void Start () {
	
		player = GameObject.Find ("goaty2");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("farmer: " + transform.position.ToString ());
		float player_x_pos = player.transform.position.x;
		float farmer_x_pos = transform.position.x;
		float diff = farmer_x_pos - player_x_pos;
		if(Mathf.Abs (farmer_x_pos - player_x_pos) < 30f){
			if((farmer_x_pos - player_x_pos) > 0){ //goat still on left
				if (facingRight)
					Flip ();
				transform.position += new Vector3(-.07f,0,0);
			}else{
				if (!facingRight)
					Flip();
				transform.position += new Vector3(.07f,0,0);
			}

		}

	}


	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;  //if facing right increase x ..     -5.674756     -2.051358-
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		
		transform.localScale = theScale;
	}
}
