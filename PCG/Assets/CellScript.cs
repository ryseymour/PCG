using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour {

	//Color notAliveColor = new Color (0 / 255f, 147 / 255f, 198 / 255f);
	//Color aliveColor = new Color (0 / 255f, 119 / 255f, 12 / 255f);

	Color notAliveColor = new Color (209 / 255f, 194 / 255f, 161 / 255f);
	Color aliveColor = new Color (93 / 255f, 117 / 255f, 70 / 255f);

	public Material material;

	//Each cell is either alive or not
	public bool alive = false;
	//This is used to 'cheaply' signal to the Update loop that we need to change the color
	//	i.e. if the previous state is different than the current state, we need to update the color
	bool previousAliveState = false;
	public bool newAliveState = false;

	public int x = -1;
	public int y = -1;

	private Transform ntclone;

	public GameObject cocoOne;

	public static int growthrate = 0;
	public static int deathrate = 0;

	public int growing = 0;
	public int dying = -1;
	public int deathdelay = 0;

	public bool deathpad = false;
	public bool bushswitch = false;

	public int treepoint = 0;

	Renderer rend;

	public static bool rain = false;
	public static bool death = false;

	public bool rainclick;

	//public GameObject cocoPre;


	// Use this for initialization
	void Start () {



		//Resources.Load ("Resources/Sand.mat", typeof(Material)) as Material;
		rend = gameObject.GetComponent<Renderer> ();
		//rend.material.mainTexture = Resources.Load ("Sand") as Texture;
		//rend.sharedMaterial = material;
		//rend.material = material.CopyPropertiesFromMaterial(Resources.Load ("Sand"));


		//this.transform.parent = (GameObject)Instantiate (Resources.Load ("CocoPre"), transform.position, transform.rotation);
		GameObject TreePre = (GameObject)Instantiate (Resources.Load ("CntPrev2"), transform.position, transform.rotation);
		TreePre.transform.parent = this.transform;

		GameObject TreePre2 = (GameObject)Instantiate (Resources.Load ("CntSPrev2"), transform.position, transform.rotation);
		TreePre2.transform.parent = this.transform;

		GameObject TreePre3 = (GameObject)Instantiate (Resources.Load ("STreePrev2"), transform.position, transform.rotation);
		TreePre3.transform.parent = this.transform;

		GameObject TreePre4 = (GameObject)Instantiate (Resources.Load ("TreeSMPrev2"), transform.position, transform.rotation);
		TreePre4.transform.parent = this.transform;

		GameObject TreePre5 = (GameObject)Instantiate (Resources.Load ("TreeLgPrev2"), transform.position, transform.rotation);
		TreePre5.transform.parent = this.transform;

		GameObject TreePre6 = (GameObject)Instantiate (Resources.Load ("BushPrev2"), transform.position, transform.rotation);
		TreePre6.transform.parent = this.transform;


		updateCellColor();
		//ntclone = transform.Find ("CntPrev2(Clone)");
	}
	
	// Update is called once per frame
	void Update () {

	


		//Debug.Log (rainTimer);

		if (rain == true && alive == false && dying <= 0) {
			if (Random.value < .025f) {
				//this.gameObject;
				alive = true;
				growing = 2;
				dying = -1;
				bushswitch = false;
				//rain = false;

			} else {
				//this.gameObject;
				alive = false;
				growing = 0;
				dying = -1;
				//rain = false;
			}
		}

		//if(death == true)
				
		

		//if (deathpad == true) {
			//growing = 0;
			//dying = -1;
		//}

		if (alive != previousAliveState) {
			//This means that something changed the cellType since the last update call, this means
			//	we need to set the color to the right color.
			updateCellColor();
			growing = growing + 1;
			//Debug.Log (growing);
		}
			


		//This is where we update the 'previous cell type' so that we can automatically update the color
		previousAliveState = alive;

		//growing = CellScript.growthrate;

		if (bushswitch == false) {
			this.transform.Find ("BushPrev2(Clone)").gameObject.SetActive (false);
			//alive = false;
			//growing = 0;
			//dying = -1;
		}

		if (growing == 1 && alive == true && dying < 0 && bushswitch == false) {
			//this.transform.GetChild (0).gameObject.SetActive (false);
			//this.transform.Find ("CntPrev2").gameObject.SetActive (false);
			//transform.GetChild (1).gameObject.SetActive (true);
			//print(transform.childCount);
			//cocoOne.SetActive(true);
			//GameObject TreePre = (GameObject)Instantiate (Resources.Load ("CntPrev2"), transform.position, transform.rotation);
			//TreePre.transform.parent = this.transform;
			//this.transform.Find ("CntPrev2(Clone)").gameObject.SetActive (true);

			this.transform.Find ("CntPrev2(Clone)").gameObject.SetActive (true);
			//treepoint = treepoint + 1;

			//GameManager.growthrate = GameManager.growthrate + 1;
		}

		//if (growing == 1 && previousAliveState == false) {
			//dying = dying + 1;
		//}

		if (growing == 3 && alive == true && dying < 0 && bushswitch == false) {
			this.transform.Find ("CntSPrev2(Clone)").gameObject.SetActive (true);
			//treepoint = treepoint + 1;

		}

		if (growing ==5 && alive == true && dying < 0 && bushswitch == false) {
			this.transform.Find ("STreePrev2(Clone)").gameObject.SetActive (true);
			//treepoint = treepoint + 1;

		}

		if (growing == 7 && alive == true && dying < 0 && bushswitch == false) {
			this.transform.Find ("TreeSMPrev2(Clone)").gameObject.SetActive (true);
			//treepoint = treepoint + 1;

		}

		if (growing >= 9 && alive == true && dying < 0 && bushswitch == false) {
			this.transform.Find ("TreeLgPrev2(Clone)").gameObject.SetActive (true);
			treepoint = treepoint + 1;

		}

		//if (growing == 2 && dying == 0  && alive == false) {
			//deathdelay = deathdelay + 1;
			//Debug.Log (deathdelay);
		//}

		//if (deathdelay == 4) {
			//growing = 0;
			//dying = -1;
		//}


		if (growing != 1 ) {
			this.transform.Find ("CntPrev2(Clone)").gameObject.SetActive (false);
			//treepoint = treepoint - 1;
		}

		if (growing != 3) {
			this.transform.Find ("CntSPrev2(Clone)").gameObject.SetActive (false);
			//treepoint = treepoint - 1;
		}

		if (growing != 5) {
			this.transform.Find ("STreePrev2(Clone)").gameObject.SetActive (false);
			//treepoint = treepoint - 1;
		}

		if (growing != 7) {
			this.transform.Find ("TreeSMPrev2(Clone)").gameObject.SetActive (false);
			//treepoint = treepoint - 1;
		}

		if (growing < 9) {
			this.transform.Find ("TreeLgPrev2(Clone)").gameObject.SetActive (false);
			//treepoint = treepoint - 1;
		}

		//if (dying * 2 >= growing && growing >7) {
		if (dying >0){
			this.transform.Find ("CntPrev2(Clone)").gameObject.SetActive (false);
			this.transform.Find ("CntSPrev2(Clone)").gameObject.SetActive (false);
			this.transform.Find ("STreePrev2(Clone)").gameObject.SetActive (false);
			this.transform.Find ("TreeSMPrev2(Clone)").gameObject.SetActive (false);
			this.transform.Find ("TreeLgPrev2(Clone)").gameObject.SetActive (false);
			this.transform.Find ("BushPrev2(Clone)").gameObject.SetActive (false);
			alive = false;
			bushswitch = false;
			growing = 0;
			dying = -1;
			//treepoint = treepoint - 1;
			//bushswitch = true;
		}

		if (dying == 0 && growing > 9){
			this.transform.Find ("TreeLgPrev2(Clone)").gameObject.SetActive (false);
			alive = false;
			growing = 0;
			dying = -1;
			bushswitch = true;
			//treepoint = treepoint - 1;

	}
		if (dying == 0 && growing >= 3) {
			this.transform.Find ("CntSPrev2(Clone)").gameObject.SetActive (false);
			//treepoint = treepoint - 1;
			//bushswitch = true;
			//alive = false;
			//dying = dying+1;

		}

		if (bushswitch == true && growing >= 1 && alive == true && dying <0) {
			this.transform.Find ("BushPrev2(Clone)").gameObject.SetActive (true);
			//treepoint = treepoint + 1;
		}

		if (bushswitch == true && growing > 0 && alive == false && dying == 0) {
			this.transform.Find ("BushPrev2(Clone)").gameObject.SetActive (false);
			alive = false;
			bushswitch = false;
			growing = 0;
			dying = -1;
			//treepoint = treepoint - 1;
		}

		//if (dying == 0) {
			//growing= growing - 1;
		//}
		//if (alive == false) {
			//growing = growing -1;
		//}
	}



	void OnMouseDown() {
		alive = !alive;
		//CellScript.growthrate = CellScript.growthrate + 1;
		Debug.Log ("this" + CellScript.growthrate);
		//this.transform.Find ("CntPrev2(Clone)").gameObject.SetActive (true);
		//GameObject cocoPre = (GameObject)Instantiate (Resources.Load ("CocoPre"), transform.position, transform.rotation);
	}



	void updateCellColor() {
		if (alive) {
			//rend.material.mainTexture = Resources.Load ("Sand") as Texture;
			rend.material.color = aliveColor;
			dying = - 1;
			Debug.Log (treepoint);
			//CellScript.growthrate = CellScript.growthrate + 1;
			//this.transform.Find ("CntPrev2(Clone)").gameObject.SetActive (true);
			//GameManager.growthrate = GameManager.growthrate + 1;

			//GameObject cocoPre = (GameObject)Instantiate (Resources.Load ("CocoPre"), transform.position, transform.rotation);
		} else {
			//rend.material.mainTexture = Resources.Load ("Sand") as Texture;
			rend.material.color = notAliveColor;
			dying =  dying + 1;
			//deathpad = true;
			//growing = growing -1;
			//growing = growing -1;
			//GameObject.Destroy ("CocoPre");
			//GameManager.deathrate = GameManager.deathrate +1;
		}


	}

	void LateUpdate()
	{
		rain = false;
	}

	//public void Rainpress (bool rainclick){
		//Debug.Log (CellScript.rain);
		//rain = true;



	//}
}
