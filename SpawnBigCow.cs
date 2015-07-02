using UnityEngine;
using System.Collections;

public class SpawnBigCow : MonoBehaviour {

	public GameObject BigCow;

	// Use this for initialization
	void Start () {
		GameObject bc = Instantiate (BigCow, transform.position, Quaternion.identity)as GameObject;
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
