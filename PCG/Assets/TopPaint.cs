using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPaint : MonoBehaviour {
	public Renderer rend;
	public int upPaint;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		applyPaint ();

		GameObject Chimney = (GameObject)Instantiate (Resources.Load ("Chimney"), transform.position, transform.rotation);
		Chimney.transform.parent = transform;
	}

	//void OnTriggerEnter (Collider other){
		//if (other.gameObject.CompareTag("House")) {
			//Destroy (other.gameObject);
			//Debug.Log ("Hit");
			//applyPaint ();
		//}
	//}

	// Update is called once per frame
	void applyPaint () {
		//Debug.Log (House.wallPaint);
		if (upPaint == 1) {
			Material upMat = Resources.Load ("Black", typeof(Material)) as Material;
			rend.sharedMaterial = upMat;} 

		else if (upPaint == 2) {
			Material upMat = Resources.Load ("Grey", typeof(Material)) as Material;
			rend.sharedMaterial = upMat;}
		//OnTriggerEnter ();
	}
	//void OnCollisionEnter (Collision col){
		//if (col.gameObject.name == "House (Clone)") {
			//Destroy (col.gameObject);
		//}
	//}
}
