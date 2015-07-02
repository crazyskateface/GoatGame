using UnityEngine;
using System.Collections;

public class spawnBigChicken : MonoBehaviour {

	public GameObject BigChicken;

	// Use this for initialization
	void Start () {
		GameObject bc = Instantiate (BigChicken, transform.position, Quaternion.identity)as GameObject;
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
