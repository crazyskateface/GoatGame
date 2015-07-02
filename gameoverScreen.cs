using UnityEngine;
using System.Collections;

public class gameoverScreen : MonoBehaviour {
	public bool activa = false;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if(Input.touchCount >= 1 && activa){
			Application.LoadLevel (1);
			
			
		}

		if(this.transform.position.z == -2f && activa != true){
			activa = true;
			Debug.Log ("ACTIVE BRUH");
		}
	}

	void SetActive(){
		activa = true;
		Debug.Log ("ACTIVE BRUH");
	}
}
