using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class PlatformerController : MonoBehaviour {

	private PlatformerCharacter2D character;
	private bool jump;
	public AwesomeJoystick moveTouchPad;
	public AwesomeJoystick jumpTouchPad;

	public float forwardSpeed = 4;
	public float backwardSpeed = 4;
	public float jumpSpeed = 16;
	public float inAirMultiplier = 0.25f;

	private Transform thisTransform;
	private Vector2 velocity;
	private bool canJump = true;
	bool controlling;


	void Awake()
	{
		controlling = GameControl.control.canControl;
		character = GetComponent<PlatformerCharacter2D>();
		thisTransform = GetComponent<Transform>();
	}
	void Start()
	{
		GameObject spawn = GameObject.Find ("PlayerSpawn");
		if(spawn)
		{
			thisTransform.position = spawn.transform.position;
		}
	}
	void OnEndGame()
	{
		moveTouchPad.Disable();
		jumpTouchPad.Disable();

		this.enabled = false;
	}
	
	void Update ()
	{
		controlling = GameControl.control.canControl;
		if(controlling){
			//check for jump
			AwesomeJoystick tp = jumpTouchPad;

			if(!tp.isFingerDown)
				canJump = true;
			if(canJump && tp.isFingerDown)
			{
				jump = true;
				canJump = false;
			}
		}
		else{
			//Debug.Log ("fail");
			//moveTouchPad.guiTexture.enabled = false;
			//jumpTouchPad.guiTexture.enabled = false;
			//moveTouchPad.Disable ();
			//jumpTouchPad.Disable ();
		}
		
	}


	
	void FixedUpdate()
	{
		if(controlling){
			float movement = 0;
			float midpoint = (2f/17f)*(Screen.width);
			//apply movement from joystick
			if( moveTouchPad.position.x > 0){
				//Debug.Log (moveTouchPad.position.x);
				movement = 1f ;
			}
			else if(moveTouchPad.position.x < 0) {
				movement = -1f; 
			}
			//movement += velocity;

			// Read the inputs.
			bool crouch = Input.GetKey(KeyCode.LeftControl);
			//#if CROSS_PLATFORM_INPUT
			//float h = CrossPlatformInput.GetAxis("Horizontal");
			//#else
			//float h = Input.GetAxis("Horizontal");
			//#endif
			
			// Pass all parameters to the character control script.
			character.Move( movement, crouch , jump );
			//Debug.Log ("MIDPOINT YALLL : "+ midpoint);
			
			// Reset the jump input once it has been used.
			jump = false;
		}else{
			//Debug.Log ("fail");

			//moveTouchPad.guiTexture.enabled = false;
			//jumpTouchPad.guiTexture.enabled = false;
			//moveTouchPad.Disable ();
			//jumpTouchPad.Disable ();
		}
	}
}


























































