using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}




	// Update is called once per frame
	void Update () {
		//if(Input.touchCount >= 1){
			//Application.LoadLevel (1);


		//}
	}

	public void Play(){
		Application.LoadLevel ("Farm");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
