using UnityEngine;
using System.Collections;

public class farmer_spawner : MonoBehaviour {

	public GameObject farmerChosen;

	// Use this for initialization
	void Start () {
		GameObject farmer = Instantiate(farmerChosen, transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
