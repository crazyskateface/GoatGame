using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public class SetLoader : MonoBehaviour {


	private List<List<UnityEngine.Object>> Bag;
	private List<List<UnityEngine.Object>> new_Bag;
	private List<UnityEngine.Object> lowset1;
	//private GameObject[] lowset1;
	private List<UnityEngine.Object> lowset2;
	private List<UnityEngine.Object> medset1;
	private List<UnityEngine.Object> medset2;
	private List<UnityEngine.Object> highset1;
	private List<UnityEngine.Object> highset2;
	private bool chxLevel = true;
	private float setPos;
	private float endpoint;
	private GameObject prevSet;
	private float previous_setPos_y = 0.0f;
	private int difficulty = 1;  // 1 - low   3 - med   5 - hard
	private int numSetsPlayed = 0;
	private float lenSet = 118.0f;
	private bool lowWithEmpty= false;
	private bool lowWithoutEmpty = false;
	private bool relevelable = false;
	// Use this for initialization
	void Start () {
		setPos = this.transform.position.x;
		Bag = new List<List<UnityEngine.Object>> ();
		new_Bag = new List<List<UnityEngine.Object>> ();
		BuildSets ();
		//PopSet (difficulty);
		numSetsPlayed++;
	}
	
	// Update is called once per frame
	void Update () {
		if (numSetsPlayed > 10 && numSetsPlayed < 20)
			difficulty = 3;
		else if (numSetsPlayed >= 20)
			difficulty = 5;

		if(setPos != this.transform.position.x){Debug.Log ("got to the 1st if statement");
			if(relevelable){Debug.Log ("Got to the 2nd if statement");
				Debug.Log (setPos-100f);
				if(GameObject.FindGameObjectWithTag ("Player").transform.position.x > setPos-100f){
					Debug.Log ("got to the 3rd if statement");
					Debug.Log (GameObject.FindGameObjectWithTag ("Player").transform.position.x.ToString ());
					Debug.Log (endpoint -100f);
					//relevel ();
					Bag = new List<List<UnityEngine.Object>> ();
					BuildSets ();
				}
			}
		}


	}

	int countsets(){
		int numsets = 0;
		for(int i=0;i < Bag.Count ;i++){
			numsets += Bag[i].Count;
		}
		Debug.Log (numsets);
		return numsets;
	}

	void relevel(){
		Debug.Log ("Rebuilding levels and repopulating game");
		BuildSets ();

	}
	

	void PopSet(int difficult){  //difficult needs to be 1, 3, or 5
		// build 3 arrays of sets 
		// create buildSets() to build variable gameobjects to work with
		// 			set1 = Bag[diff]     low = get gameobjects where name starts with set ,same w/ med, high arrays
		// based on diff, gra7b set from array,  place chx every other set
		int totalsets = countsets ();
		for (int i=0; i< totalsets+1;i++){
			if (chxLevel) {
				difficult--;
				chxLevel = false;
			}else{
				//Debug.Log ("should be difficult++");
				difficult++;
				chxLevel = true;
			}
			List<UnityEngine.Object> setlist;


			if(Bag.Count != 0){
				if (Bag[difficult].Count != 0){
					setlist = Bag [difficult];
					int r = (int)UnityEngine.Random.Range (0, setlist.Count - 1);
					
					GameObject setPiece;
					
					setPiece = (GameObject)setlist [r];
					float size = float.Parse(setPiece.transform.Find ("size").transform.GetChild (0).name);
					SetScript endpointer;

					if (prevSet != null){
						endpointer = prevSet.GetComponent<SetScript>();
						endpoint = endpointer.endPoint;

					}

					setPos += endpoint;//+ previous_setPos_y;
					if(setPiece.gameObject.name == "set2"){
						setPos += 63;
					}
					//Debug.Log (setPiece.gameObject.name);
					//previous_setPos_y = size;
					GameObject pieceLevel = Instantiate (setPiece, new Vector3 (setPos, transform.position.y, transform.position.z), transform.rotation)as GameObject;
					prevSet = pieceLevel;
					//new_Bag [difficult].append(r);
					Bag [difficult].RemoveAt (r);
					Debug.Log ("Bag 0: "+Bag[0].Count.ToString ());
					Debug.Log ("Bag 1: "+Bag[1].Count.ToString ());
					Debug.Log ("Bag 2: "+Bag[2].Count.ToString ());
					Debug.Log ("Bag 3: "+Bag[3].Count.ToString ());
					Debug.Log ("Bag 4: "+Bag[4].Count.ToString ());
				}
				else if(Bag[difficult+1].Count != 0){
					setlist = Bag[difficult+1];
					int r = (int)UnityEngine.Random.Range (0, setlist.Count - 1);
					
					GameObject setPiece;
					
					setPiece = (GameObject)setlist [r];
					float size = float.Parse(setPiece.transform.Find ("size").transform.GetChild (0).name);
					SetScript endpointer;
					
					if (prevSet != null){
						endpointer = prevSet.GetComponent<SetScript>();
						endpoint = endpointer.endPoint;

					}
					
					setPos += endpoint;//+ previous_setPos_y;
					if(setPiece.gameObject.name == "set2"){
						setPos += 63;
					}
					//Debug.Log (setPiece.gameObject.name);
					//previous_setPos_y = size;
					GameObject pieceLevel = Instantiate (setPiece, new Vector3 (setPos, transform.position.y, transform.position.z), transform.rotation)as GameObject;
					prevSet = pieceLevel;
					//new_Bag [difficult].append(r);
					Bag [difficult+1].RemoveAt (r);
					Debug.Log ("Bag 0: "+Bag[0].Count.ToString ());
					Debug.Log ("Bag 1: "+Bag[1].Count.ToString ());
					Debug.Log ("Bag 2: "+Bag[2].Count.ToString ());
					Debug.Log ("Bag 3: "+Bag[3].Count.ToString ());
					Debug.Log ("Bag 4: "+Bag[4].Count.ToString ());

				}
				else{
					relevelable = true;
					//Debug.Log ("relevelable = true");
				}
			}
			
		}
	}

	void BuildSets(){
		//build 2d array sets
		
		lowset1 = (Resources.LoadAll("lowsetwith")).ToList ();
		
		
		//lowset1 = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Cast<GameObject>().Where(g=>g.tag=="lowsetwith").ToList();
		Bag.Add (lowset1);
		
		//Debug.Log ("Getting sets heres lowset1: " + lowset1.Count.ToString ());
		
		lowset2 = (Resources.LoadAll("lowsetwithout")).ToList();
		Bag.Add (lowset2);
		//Debug.Log ("Getting sets heres lowset2: " + lowset2.Count.ToString ());
		
		medset1 = (Resources.LoadAll("medsetwith")).ToList();
		Bag.Add (medset1);
		
		medset2 = (Resources.LoadAll("medsetwithout")).ToList();
		Bag.Add (medset2);
		
		highset1 = (Resources.LoadAll("highsetwith")).ToList();
		Bag.Add (highset1);
		
		highset2 = (Resources.LoadAll("highsetwithout")).ToList();
		Bag.Add (highset2); 
		
		PopSet (difficulty);
		
	}







}
