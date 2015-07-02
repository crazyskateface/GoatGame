using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {


	GameObject player;
	GameControl control;
	// Use this for initialization
	void Start () {
		control = GameControl.control;
		player = GameObject.Find ("goaty2");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator hit(){

		SpriteRenderer[] parts = player.GetComponentsInChildren<SpriteRenderer>();
		player.layer = 14;
		for(int i=0;i<20;i++){
			foreach(SpriteRenderer pock in parts){
				if(pock.enabled)
					pock.enabled = false;
				else
					pock.enabled = true;
			}
			yield return new WaitForSeconds(.1f);
		}
		player.layer = 15;

	

//		GameObject part = player.transform.GetChild(0).gameObject;
//		SpriteRenderer ren = part.GetComponent<SpriteRenderer>();
//		player.layer = 14;
//		for(int i=0;i<20;i++){
//			if(ren.enabled)
//				ren.enabled = false;
//			else
//				ren.enabled = true;
//			yield return new WaitForSeconds(.1f);
//		}
//
//		player.layer = 15;
		
	}




	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject == player && player.layer != 14){

			Debug.Log ("hit enemy");
			//play sound
			control.health -= 25;

			//pigBounce.Play ();
			other.rigidbody.AddForce (new Vector2(0f,500f));
			StartCoroutine ("hit");
		
		}
	}










}












































