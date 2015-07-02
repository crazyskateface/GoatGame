using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public Transform PlayerSpawnz;
	private bool hasTriggered = false;
	// Use this for initialization
	void Start () {
	 
	}


	void OnTriggerEnter2D(Collider2D other){

		Debug.Log ("Trigger entered");
		if(!(GameObject.Find ("PlayerSpawn(Clone)")) && !hasTriggered){

			Debug.Log ("yea dog");
			GameObject spawn = Instantiate (PlayerSpawnz,transform.position, transform.rotation) as GameObject;
			spawn.name = "PlayerSpawn";
			GameControl control = GameControl.control;
			control.checkedPoint = true;
			control.checkpointPosition = spawn.transform.position;
			DontDestroyOnLoad(spawn);
			hasTriggered = true;
		}

	}


	// Update is called once per frame
	void Update () {
	
	}
}
