using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour {

	//public Text livestextUI;
	public GameObject Player;
	public bool grounded = false;
	public int plant_count = 0;
	public GameObject Arrow;
	//public Coroutine MovePlayer;



	CharacterController cc;

	float rotateSpeed = 100f;
	float movementSpeed = 5f;
	float yVelocity = 0;
	float jumpSpeed = 0.35f;

	float gravity = -1f;
	float gravityVelocity = 0;

	public int score = 0;

	// Use this for initialization
	void Start () {
		cc = gameObject.GetComponent<CharacterController> ();


	}

	// Update is called once per frame
	void Update () {
		//GameObject livestextUIObject = GameObject.Find ("Lives");
		//livestextUI = livestextUIObject.GetComponent<Text> ();
		//livestextUI.text = "lives: " + lives.ToString ();
		//lives.text = "lives: " + lives.ToString ();


		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");

		transform.Rotate (0, hAxis * rotateSpeed * Time.deltaTime, 0);
		//gravityVelocity = gravityVelocity + gravity * Time.deltaTime;
		if (!cc.isGrounded) {// SAME THING AS: if (cc.isGrounded == false) {
			//Apply gravity to the velocity
			yVelocity = yVelocity + gravity * Time.deltaTime;

			//If we are moving upwards, and we have released the space bar, set the upward velocity to 0,
			//this will make it so the player will start falling (from gravity) when the player releases the space bar
			if (Input.GetKeyUp (KeyCode.Space) && yVelocity > 0) {
				yVelocity = 0;
			}
		} else {
			//Grounded
			if (Input.GetKeyDown (KeyCode.Space)) {
				//Jump!
				yVelocity = jumpSpeed;
			}
		}



		//Vector3 motion = transform.forward * vAxis * movementSpeed * Time.deltaTime;
		//motion.y = motion.y + gravityVelocity;
		//cc.Move (motion)
	

	Vector3 motion = transform.forward * vAxis * movementSpeed * Time.deltaTime;
	//Set the y velocity value that we have been managing ourselves above
	//In this value, we have accounted for jumping and gravity
	motion.y = yVelocity;
		
	cc.Move (motion);
	



	}
		
	IEnumerator MovePlayer() {
		yield return new WaitForSeconds (.5f);
		GameObject playerspawn = GameObject.Find ("Plant_spawner");
		this.gameObject.transform.position = playerspawn.transform.position;
	}

	void OnTriggerEnter (Collider other){


		if (other.gameObject.tag == "Jump") {
			float vAxis = Input.GetAxis ("Vertical");
			Vector3 motion = transform.forward * vAxis * movementSpeed * Time.deltaTime;
			yVelocity = jumpSpeed;
		}

	

		if (other.gameObject.CompareTag ("Wall"))
			{
			yVelocity = 0;
	}

	}

	void OnGUI() {
		GUI.Label (new Rect (50, 75, 100, 100), score.ToString ());
	}
	}