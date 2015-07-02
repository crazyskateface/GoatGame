using UnityEngine;
using System.Collections;

public class titleanimations : MonoBehaviour {

	public GameObject goat;
	public GameObject farmer;
	public GameObject startmarker;
	public GameObject endmarker;
	bool lerped;
	bool passed;
	float startTime;
	float fstartTime;
	float journeyLength;
	Animator goatanim;
	Animator farmeranim;

	// Use this for initialization
	void Start () {
		goatanim = goat.GetComponent<Animator> ();
		farmeranim = farmer.GetComponent<Animator> ();
		goatanim.SetBool ("Ground", true);
		//goatanim.SetFloat ("Speed", 3.0f);
		goatanim.SetFloat ("vSpeed", 0.0f);
		Time.timeScale = 1;
		lerped = false;
		goat.transform.position = startmarker.transform.position;
		startTime = Time.time;
		fstartTime = startTime + 2.0f;
		journeyLength = Vector3.Distance(startmarker.transform.position, endmarker.transform.position);
		passed = false;
		Debug.Log (fstartTime);
	}



	// Update is called once per frame
	void Update () {
		if(Input.touchCount >= 1){
			Application.LoadLevel (1);
		
		
		}
		Debug.Log (Time.time);
		float distCovered = (Time.time - startTime) * 6.0f;
		float fracJourney = distCovered / journeyLength;
		goat.transform.position = Vector3.Lerp (startmarker.transform.position, endmarker.transform.position, fracJourney);

		if(goat.transform.position.x >= (endmarker.transform.position.x - 0.5f) && farmer.transform.position.x >= (endmarker.transform.position.x - 0.5f)){
			goat.transform.position = startmarker.transform.position;
			lerped = true;
			startTime = Time.time;
			fstartTime = startTime + 2.0f;
			passed = false;
			farmer.transform.position = startmarker.transform.position;

		}
		if(Time.time >= fstartTime){
			passed =true;
			Debug.Log ("passed time");
		}



		if (passed){

			float fdistCovered = (Time.time - fstartTime) * 6.0f;
			float ffracJourney = fdistCovered / journeyLength;
			Vector3 startpossy = startmarker.transform.position - new Vector3(0,.5f,0);
			Vector3 endpossy = endmarker.transform.position - new Vector3(0,.5f,0);
			farmer.transform.position = Vector3.Lerp (startpossy, endpossy, ffracJourney);
			

		}
	}

}
