using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class spawnCritter : MonoBehaviour {

	private List<UnityEngine.Object> crits;


	// Use this for initialization
	void Start () {
		getCrittersToList ();



	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void getCrittersToList(){

		crits = (Resources.LoadAll("Critters")).ToList ();
		int r = (int)UnityEngine.Random.Range (0, crits.Count);
		Debug.Log ("rand num = " + r + "  and actual size = " + crits.Count);
		GameObject critterChosen = (GameObject)crits [r];
		GameObject critter = Instantiate(critterChosen, transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject);
	}
}
