using UnityEngine;
using System.Collections;

public class guiscript : MonoBehaviour {

	GameControl control;
	public GUISkin guiskin;
	public Texture2D play;
	public Texture2D replay;
	public Texture2D ldrboard;
	public Texture2D home;
	public Texture2D pause;
	public Texture2D help;
	public Texture2D HealthFull;
	public Texture2D Health75;
	public Texture2D HealthHalf;
	public Texture2D Health25;
	public Texture2D HealthNone;
	Texture2D healthTex;
	GUIContent timeContent;

	public bool paused = false;
	public bool DEATH = false;

	int goodWidth = 350;
	int goodheight = 300;
	int timesize;


	// Use this for initialization
	void Start () {
		control = GameControl.control;
		healthTex = HealthFull;


	}
	
	// Update is called once per frame
	void Update () {
		paused = control.paused;
		DEATH = control.DEATH;

		if (control.health <= 0) {
			healthTex = HealthNone;
		} else if (control.health <= 25) {
			healthTex = Health25;
		} else if (control.health <= 50) {
			healthTex = HealthHalf;
		} else if (control.health <= 75) {
			healthTex = Health75;
		}
		else{
			healthTex = HealthFull;
		}
	}


	void OnGUI () {
		GUI.skin = guiskin; 
		//GUI.Label (new Rect(10,10,100,30),"Health: " + health);
		//GUI.color = Color.red;
		GUI.contentColor = Color.white;
		GUI.DrawTexture (new Rect (10, 10, 200, 75), healthTex);
		GUI.Label (new Rect(10,100,300,30),"Score: " + control.score);
		GUI.Label (new Rect(Screen.width/2-100,0,200,30),"Time: " + (int)control.levelTime);
		//GUI.HorizontalScrollbar (new Rect (10,10,100,30),0,control.health,0,100);

		int psize = Screen.width/10;
		//Debug.Log ("paused: " + paused.ToString () + " DEATH: " + DEATH.ToString () + " menu: " + menu.ToString ());
		// PAUSE THE GAME BRING UP PAUSE MENU
		if (!paused && !DEATH){
			if (GUI.Button (new Rect (Screen.width - psize, 0, psize, psize), new GUIContent ("", pause))) {
				//Time.timeScale = 0;
				control.SendMessage ("pauseGame",1);
				paused = true;
			}
		}
		if(paused && !DEATH){
			
			if (GUI.Button (new Rect (Screen.width - psize, 0, psize, psize), new GUIContent ("", pause))) {
				//Time.timeScale = 1;
				control.SendMessage ("pauseGame",2);
				paused= false;
			}
			GUI.Box(new Rect(Screen.width/2 - 320,0,640,600),"Paused");
			GUI.BeginGroup(new Rect(Screen.width/2 - 320,50,640,600));
			if(GUI.Button(new Rect(10,70,200,200),new GUIContent("", play))){
				control.SendMessage ("pauseGame",2);
				//Time.timeScale = 1;
			}
			if(GUI.Button (new Rect (220, 70, 200, 200), new GUIContent("", home))){
				//DEATH = true;
				//areyousure = true;
				control.SendMessage ("pauseGame",2);
				//menu=true;
				control.SendMessage ("reset", 3);
			}
			if(GUI.Button (new Rect (430, 70, 200, 200), new GUIContent ("", help))){
				//showhelpscreen
				GUI.Label (new Rect(0,0,100,100),"Fuck you");
			}
			GUI.EndGroup ();
		}
		
		//		if(areyousure){
		//			GUI.Box(new Rect(Screen.width/2 - Screen.width/3,0,640,500),"Quit to main menu?");
		//			GUI.BeginGroup(new Rect(Screen.width/2 - Screen.width/3,50,640,500));
		//			if(GUI.Button(new Rect((640/2)-195,70,200,200),new GUIContent("", play))){
		//				areyousure = false;
		//				paused = false;
		//				Time.timeScale = 1;
		//			}
		//			if(GUI.Button (new Rect ((640/2)+5, 70, 200, 200), new GUIContent("", home))){
		//				areyousure=false;
		//				paused=false;
		//				reset (0);
		//			}
		//			GUI.EndGroup ();
		//		}
		
		
		if(control.DEATH){
			
			GUI.Box(new Rect(Screen.width/2 - 320,0,640,600),"Game Over!");
			GUI.BeginGroup(new Rect(Screen.width/2 - 320,50,640,600));
			GUI.Label (new Rect(50,50,goodWidth,goodheight),"Critters: "+control.score/10);
			GUI.Label (new Rect(50,100,goodWidth,goodheight),"Score: "+control.score);
			if(GUI.Button(new Rect(10,170,200,200),new GUIContent("", replay))){
				control.SendMessage ("reset", 1);
			}
			if(GUI.Button (new Rect (220, 170, 200, 200), new GUIContent("", ldrboard))){
				control.SendMessage ("Authenticate");
			}
			if(GUI.Button (new Rect (430, 170, 200, 200), new GUIContent ("", home))){
				control.SendMessage ("reset", 3);
			}
			//toggleTxt = GUI.Toggle(Rect(0, 75, 200, 30), toggleTxt, "I am a Toggle button");
			//toolbarInt = GUI.Toolbar (Rect (0, 110, 250, 25), toolbarInt, toolbarStrings);
			//selGridInt = GUI.SelectionGrid (Rect (0, 170, 200, 40), selGridInt, selStrings, 2);
			//hSliderValue = GUI.HorizontalSlider (Rect (0, 210, 100, 30), hSliderValue, 0.0, 1.0);
			//hSbarValue = GUI.HorizontalScrollbar (Rect (0, 230, 100, 30), hSbarValue, 1.0, 0.0, 10.0);
			GUI.EndGroup ();
			
			
			
			//string buttonLabel = Social.localUser.authenticated ? "Sign Out"  : "Leaderboard";
			//Rect buttonRect = new Rect(0.25f * Screen.width/3, 0.25f * Screen.height/3,
			//0.5f * Screen.width/3, 0.5f * Screen.height/3);
			
		}

	}
}
