using UnityEngine;
using System.Collections;

public class PiggyScript : MonoBehaviour {

	public AudioSource pigBounce;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.position.y > this.transform.position.y +1f)
		{
			Debug.Log ("entered collider");
			//play sound

			pigBounce.Play ();
			other.rigidbody.AddForce (new Vector2(0f,300f));
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
