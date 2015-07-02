using UnityEngine;
using System.Collections;

public class controlPlayerdata : MonoBehaviour {

	// Use this for initialization
	void OnGUI () {
		if(GUI.Button (new Rect(10, 100, 100, 30), "Health up"))
		{
			GameControl.control.health += 10;
		}
		if(GUI.Button (new Rect(10,140,100,30),"Score up"))
		{
			GameControl.control.score += 10;
		}
		if(GUI.Button (new Rect(10,220,100,30),"Save"))
		{
			GameControl.control.Save ();
		}
		if(GUI.Button (new Rect(10,260,100,30),"Load"))
		{
			GameControl.control.Load ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
