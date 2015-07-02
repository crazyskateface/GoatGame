using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class GameControl : MonoBehaviour {

	public static GameControl control;


	public float levelTime;
	public float timeElapsed;
	public int fontsize;
	public float health;
	public int score;
	public bool canControl = true;
	public Vector3 checkpointPosition;

	//vars for bags and sets

	private float playerPos;
	//private bool menu = false;
	public bool DEATH = false;
	private int maxhealth = 100;
	public bool paused = false;
	private int psize;
	private bool areyousure = false;
	public bool checkedPoint = false;
	public GameObject set;

	GameObject player;
	GameObject twoDCont;

	private const float FontSizeMult = 0.05f;
	private bool mWaitingForAuth = false;
	private string mAuthProgressMessage = "Authenticated?";
	private string mStatusText = "Ready.";
	
	//private bool Authenticated = false;
	// what is the highest score we have posted to the leaderboard?
	private int mHighestPostedScore = 0;
	private bool mAuthenticating = false;


	// Use this for initialization
	void Awake () {
		levelTime = 30.0f;
		timeElapsed = 0.0f;
		//GameObject pieceLevel = Instantiate (set, transform.position, transform.rotation)as GameObject;

		if(control == null)
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		}
		else if(control != this)
		{
			Destroy (gameObject);
		}


	}

	void Start(){
		player = GameObject.Find("goaty2");
		twoDCont =GameObject.Find ("2d Side Scroller2");
		PlayGamesPlatform.DebugLogEnabled = true;
		
		PlayGamesPlatform.Activate();
		//Authenticate ();

		DEATH = false;
		paused = false;
		Time.timeScale = 1;



	}

	void Update(){
		timeElapsed += Time.deltaTime;  // add to elapsed game time

		levelTime -= Time.deltaTime;    // countdown time for time left til death do him part
		if(health <= 0 || levelTime <=0.0f || Input.GetKeyDown ("w")){
			GameOver ();
		}

//		if (player.transform.position.x >= (setPos)){ //check if player is at halfway mark and call level spawn
//			//BuildSets ();
//			PopSet(difficulty);
//			numSetsPlayed++;
//		}
		//if(Input.touchCount >= 1 && DEATH){
			//DEATH = false;
			//reset ();			
		//}

//		if(checkedPoint && checkpointPosition == null){
//			checkpointPosition = GameObject.Find ("PlayerSpawn").transform.position;
//
//		}



	}
	void reset(int level = 1){

		//GameObject.Find ("set1(clone)").name = "set1";GameObject.Find("set2(clone)").name="set2";GameObject.Find ("set4(clone)").name="set4";

		DEATH = false;
		levelTime = 30.0f;
		timeElapsed = 0.0f;
		score = 0;
		health = 100;
		//Application.LoadLevel (1);
		canControl = true;
		Time.timeScale = 1;
		if(level == 3){
			level = 0;
		}
		Application.LoadLevel (level);
		//if(level == 0){
			//DestroyImmediate (gameObject);
		//}
		//GameObject pieceLevel = Instantiate (Bag[0][0], new Vector3 (setPos, transform.position.y, transform.position.z), transform.rotation)as GameObject;

	}

	void addTime(){
		levelTime += 30f;

	}

	void pauseGame(int psd){
		if(psd ==  1){
			//unpaused
			paused = true;
			Time.timeScale = 0;
		}else{
			paused = false;
			Time.timeScale = 1;
		}
	}


	void GameOver(){
		//player.gameObject.SendMessage ("death");
		
		//Application.LoadLevel (1);
		//GameObject gameoverscreen = GameObject.Find ("GameOver");
		//gameoverscreen.transform.position = new Vector3(gameoverscreen.transform.position.x, gameoverscreen.transform.position.y,-2f);
		DEATH = true;
		PostToLeaderboard ();
		canControl = false;
		Time.timeScale = 0;
		//pos = -2f;
	}

	void AddScore(){
		control.score += 10;

	}


	void OnGUI()
	{

	}
	
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();
		data.health = health;
		//data.score = score;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if(File.Exists (Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();

			health = data.health;
			//score = data.score;

		}
	}

	public void Authenticate() {
        if (Authenticated || mAuthenticating) {
            Debug.LogWarning("Ignoring repeated call to Authenticate().");
			PostToLeaderboard();
			ShowLeaderboardUI();
            return;
        }


        // Enable/disable logs on the PlayGamesPlatform
        //PlayGamesPlatform.DebugLogEnabled = GameConsts.PlayGamesDebugLogsEnabled;

        //PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        //PlayGamesPlatform.InitializeInstance(config);

        // Activate the Play Games platform. This will make it the default
        // implementation of Social.Active
        PlayGamesPlatform.Activate();

        // Set the default leaderboard for the leaderboards UI
		((PlayGamesPlatform) Social.Active).SetDefaultLeaderboardForUI("CgkIr--1i-YPEAIQAg");

        // Sign in to Google Play Games
        mAuthenticating = true;
        Social.localUser.Authenticate((bool success) => {
            mAuthenticating = false;
            if (success) {
               Debug.Log("Login successful!");
				ShowLeaderboardUI();
            } else {
                // no need to show error message (error messages are shown automatically
                // by plugin)
                Debug.LogWarning("Failed to sign in with Google Play Games.");
            }
        });
    }

    public bool Authenticating {
        get {
            return mAuthenticating;
        }
    }

    public bool Authenticated {
        get {
            return Social.Active.localUser.authenticated;
        }
    }

    public void SignOut() {
        ((PlayGamesPlatform) Social.Active).SignOut();
    }

    public string AuthProgressMessage {
        get {
            return mAuthProgressMessage;
        }
    }

    public void ShowLeaderboardUI() {
        if (Authenticated) {
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAchievementsUI() {
        if (Authenticated) {
            Social.ShowAchievementsUI();
        }
    }

    public void PostToLeaderboard() {
        //int score = mProgress.TotalScore;
        if (Authenticated && score > mHighestPostedScore) {
            // post score to the leaderboard
			Social.ReportScore(score, "CgkIr--1i-YPEAIQAg", (bool success) => {});
            mHighestPostedScore = score;
        }
		else if(!Authenticated && score > mHighestPostedScore){
			Authenticate ();
			//while(!Authenticated){
				//Debug.Log ("waiting for auth ");
			//}
			Social.ReportScore(score, "CgkIr--1i-YPEAIQAg", (bool success) => {});
			mHighestPostedScore = score;
		}
	}
	
	
}

[Serializable]
class PlayerData
{
	public float health;
	public float score;


}