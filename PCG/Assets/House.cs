using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	public float width = 10f;
	public float height = 10f;
	public float depth = 10f;

	public float stories;

	//public GameObject[] colorArray;

	float randomY; 

	public float wallThickness = 3f;

	//public static int wallPaint;

	public GameObject frontWall;
	public GameObject frontWall2;
	public GameObject frontWall3;
	public GameObject backWall;
	public GameObject backWall2;
	public GameObject leftWall;
	public GameObject leftWall2;
	public GameObject rightWall;
	public GameObject rightWall2;
	public GameObject topWall;
	public GameObject topWall2;
	public GameObject bottomWall;
	public GameObject doorWall;
	//public GameObject Coin;

	public int Color;




	// Use this for initialization
	void Start () {
		float randomY = Random.Range (0, 360);
		Quaternion rotation = Quaternion.Euler(0,randomY, 0);
		this.transform.rotation = rotation;

		float xPos = transform.position.x + Random.Range(-transform.localScale.x/2, transform.localScale.x/2);
		float yPos = transform.position.y;
		float zPos = transform.position.z + Random.Range(-transform.localScale.z/2, transform.localScale.z/2);
		Vector3 pos = new Vector3 (xPos, yPos, zPos);

	}


	// Update is called once per frame
	void Update () {

	}


	public void constructHouse ()
	{
		//1. Instantiate 4 walls
		frontWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		frontWall.name = "Front";
		frontWall2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		frontWall2.name = "Front2";
		frontWall3 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		frontWall3.name = "Front3";
		backWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		backWall.name = "Back";
		backWall2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		backWall2.name = "Back2";
		leftWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		leftWall.name = "Left";
		leftWall2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		leftWall2.name = "Left2";
		rightWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		rightWall.name = "Right";
		rightWall2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		rightWall2.name = "Right2";
		topWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		topWall.name = "Top";
		topWall2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		topWall2.name = "Top2";
		bottomWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		bottomWall.name = "Floor";
		doorWall = GameObject.CreatePrimitive (PrimitiveType.Cube);
		doorWall.name = "Door";
		GameObject Coin = (GameObject)Instantiate (Resources.Load ("Coin"), transform.position, transform.rotation);
		//GameObject Chimney = (GameObject)Instantiate (Resources.Load ("Chimney"), transform.position, transform.rotation);

		//Make the walls a child of the house
		frontWall.transform.parent = transform;
		frontWall2.transform.parent = transform;
		frontWall3.transform.parent = transform;
		backWall.transform.parent = transform;
		backWall2.transform.parent = transform;
		leftWall.transform.parent = transform;
		leftWall2.transform.parent = transform;
		rightWall.transform.parent = transform;
		rightWall2.transform.parent = transform;
		topWall.transform.parent = transform;
		topWall2.transform.parent = transform;
		bottomWall.transform.parent = transform;
		doorWall.transform.parent = transform;
		Coin.transform.parent = transform;

		rebuildHouse ();
	}

//}

	//}

	public void rebuildHouse ()
	{
		//2. Scale them appropriately
		Vector3 doorDimension = new Vector3 (width / 3, height, wallThickness);
		Vector3 frontAndBackDimension = new Vector3 (width, height, wallThickness);
		Vector3 frontAndBackDimension2 = new Vector3 (width, height, wallThickness);
		Vector3 leftAndRightDimension = new Vector3 (wallThickness, height, depth);
		Vector3 topDimension = new Vector3 (width, wallThickness, depth);
		frontWall.transform.localScale = doorDimension;
		frontWall2.transform.localScale = doorDimension;
		frontWall3.transform.localScale = frontAndBackDimension;
		backWall.transform.localScale = frontAndBackDimension;
		backWall2.transform.localScale = frontAndBackDimension;
		leftWall.transform.localScale = leftAndRightDimension;
		leftWall2.transform.localScale = leftAndRightDimension;
		rightWall.transform.localScale = leftAndRightDimension;
		rightWall2.transform.localScale = leftAndRightDimension;
		topWall.transform.localScale = topDimension;
		topWall2.transform.localScale = topDimension;
		bottomWall.transform.localScale = topDimension;
		doorWall.transform.localScale = doorDimension;

		Quaternion rotation = Quaternion.Euler (0, randomY, 0);
		this.transform.rotation = rotation;

		//3. Position them appropriately
		frontWall.transform.position = new Vector3 (transform.position.x + width / 3, 
			transform.position.y + height / 2, 
			transform.position.z - depth / 2 - wallThickness / 2);
		frontWall2.transform.position = new Vector3 (transform.position.x - width / 3, 
			transform.position.y + height / 2, 
			transform.position.z - depth / 2 - wallThickness / 2);
		frontWall3.transform.position = new Vector3 (transform.position.x, 
			transform.position.y + (height) +(height /2), 
			transform.position.z - depth / 2 - wallThickness / 2);
		doorWall.transform.position = new Vector3 (transform.position.x, 
			transform.position.y + height / 2, 
			transform.position.z - depth / 2 - wallThickness / 2);
		backWall.transform.position = new Vector3 (transform.position.x, 
			transform.position.y + height / 2, 
			transform.position.z + depth / 2 + wallThickness / 2);
		backWall2.transform.position = new Vector3 (transform.position.x, 
			transform.position.y + (height) +(height /2), 
			transform.position.z + depth / 2 +wallThickness / 2);
		leftWall.transform.position = new Vector3 (transform.position.x - width / 2 + wallThickness / 2, 
			transform.position.y + height / 2, 
			transform.position.z);
		leftWall2.transform.position = new Vector3 (transform.position.x - width / 2 + wallThickness / 2, 
			transform.position.y + (height) + (height / 2), 
			transform.position.z);
		rightWall.transform.position = new Vector3 (transform.position.x + width / 2 - wallThickness / 2, 
			transform.position.y + height / 2, 
			transform.position.z);
		rightWall2.transform.position = new Vector3 (transform.position.x + width / 2 - wallThickness / 2, 
			transform.position.y + (height) + (height / 2), 
			transform.position.z);
		topWall.transform.position = new Vector3 (transform.position.x, transform.position.y + height - wallThickness / 2, transform.position.z);
			topWall2.transform.position = new Vector3 (transform.position.x, transform.position.y + (height)+(height) - wallThickness / 2, transform.position.z );
		bottomWall.transform.position = new Vector3 (transform.position.x, transform.position.y + wallThickness / 2, transform.position.z );
		//GameObject Chimney = (GameObject)Instantiate (Resources.Load ("Chimney"), transform.position.x, transform.position.y + height - wallThickness / 2, transform.position.z);

		//Coin.transform.position =  new Vector3 (transform.position.x, transform.position.y + wallThickness / 2, transform.position.z);



		applyColor ();
	


	}
	public void applyColor (){
		float paint = Random.Range (1, 25);
		float topAndBottom = Random.Range (1, 25);

		//Debug.Log (paint);

		if (paint > 1.0f && paint < 10.0f) {
			WallPaint color = frontWall.GetComponentInChildren<WallPaint>();
			color.wallPaint = 2;
			WallPaint color5 = frontWall2.GetComponentInChildren<WallPaint>();
			color5.wallPaint = 2;
			WallPaint color6 = frontWall3.GetComponentInChildren<WallPaint>();
			//frontWall3.gameObject.SetActive (false);
			color6.wallPaint = 2;
			WallPaint color2 = backWall.GetComponentInChildren<WallPaint>();
			color2.wallPaint = 2;
			WallPaint color7 = backWall2.GetComponentInChildren<WallPaint>();
			//backWall2.gameObject.SetActive (false);
			color7.wallPaint = 2;
			WallPaint color3 = rightWall.GetComponentInChildren<WallPaint>();
			color3.wallPaint = 2;
			WallPaint color8 = rightWall2.GetComponentInChildren<WallPaint>();
			color8.wallPaint = 2;
			//rightWall2.gameObject.SetActive (false);
			WallPaint color4 = leftWall.GetComponentInChildren<WallPaint>();
			color4.wallPaint = 2;
			WallPaint color9 = leftWall2.GetComponentInChildren<WallPaint>();
			//leftWall2.gameObject.SetActive (false);
			color9.wallPaint = 2;


			//Color = 1;





		} else if (paint > 10.0f) {
			WallPaint color = frontWall.GetComponentInChildren<WallPaint>();
			color.wallPaint = 1;
			WallPaint color5 = frontWall2.GetComponentInChildren<WallPaint>();
			color5.wallPaint = 1;
			WallPaint color6 = frontWall3.GetComponentInChildren<WallPaint>();
			color6.wallPaint = 1;
			WallPaint color2 = backWall.GetComponentInChildren<WallPaint>();
			color2.wallPaint = 1;
			WallPaint color7 = backWall2.GetComponentInChildren<WallPaint>();
			color7.wallPaint = 1;
			WallPaint color3 = rightWall.GetComponentInChildren<WallPaint>();
			color3.wallPaint = 1;
			WallPaint color8 = rightWall2.GetComponentInChildren<WallPaint>();
			color8.wallPaint = 1;
			WallPaint color4 = leftWall.GetComponentInChildren<WallPaint>();
			color4.wallPaint = 1;
			WallPaint color9 = leftWall2.GetComponentInChildren<WallPaint>();
			color9.wallPaint = 1;

			//Color = 2;
		}

		if (topAndBottom > 1.0f && topAndBottom < 10.0f) {
			TopPaint color = topWall.GetComponentInChildren<TopPaint>();
			color.upPaint = 1;
			TopPaint color3 = topWall2.GetComponentInChildren<TopPaint> ();
			color3.upPaint = 1;
			//TopPaint color2 = bottomWall.GetComponentInChildren<TopPaint1>();
			//color2.upPaint = 1;
		} else if (topAndBottom > 10.0f)  {
			TopPaint color = topWall.GetComponentInChildren<TopPaint>();
			color.upPaint = 2;
			//TopPaint color2 = bottomWall.GetComponentInChildren<TopPaint1>();
			//color2.upPaint = 2;
			TopPaint color3 = topWall2.GetComponentInChildren<TopPaint> ();
			color3.upPaint = 2;

		}



		enableStory ();

	

}
	void enableStory (){

		float stories = Random.Range (1, 10);
		//Debug.Log (stories);

		if (stories < 8.0f) {
			this.frontWall3.gameObject.SetActive (false);
			this.backWall2.gameObject.SetActive (false);
			this.leftWall2.gameObject.SetActive (false);
			this.rightWall2.gameObject.SetActive (false);
			this.topWall2.gameObject.SetActive (false);
			//frontWall3.GetComponentInChildren<Renderer>();
			//GameObject off1 =gameObject("frontWall3");
			//.SetActive (false);

		}

	

	}
	//void Collision (Collider other){


	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag("House")) {
			//Destroy (this.gameObject);
			//Debug.Log ("Hit");
			//this.gameObject.transform = new Vector3 (transform.position.x + 5, transform.position.y, transform.position.z -5);
			//other.gameObject.transform.localPosition = new Vector3 (xPos, yPos, zPos);
			transform.Translate (Random.Range (-20.0f, 20.0f), 0, Random.Range (-20.0f, 20.0f));

			//this.gameObject.transform.Translate = new Vector3 (transform.position.x + Random.Range (-transform.localScale.x / 2, transform.localScale.x / 2), 0, 
				//transform.position.z + Random.Range (-transform.localScale.z / 2, transform.localScale.z / 2));

			rebuildHouse ();
		//}
	}
	}
}

//}
