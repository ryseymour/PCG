using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 5f, 0);
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag("Player")) {
			Destroy (this.gameObject);
			//Debug.Log ("Hit");
			//this.gameObject.transform = new Vector3 (transform.position.x + 5, transform.position.y, transform.position.z -5);
			//other.gameObject.transform.localPosition = new Vector3 (xPos, yPos, zPos);
			//transform.Translate (Random.Range (-20.0f, 20.0f), 0, Random.Range (-20.0f, 20.0f));

			//this.gameObject.transform.Translate = new Vector3 (transform.position.x + Random.Range (-transform.localScale.x / 2, transform.localScale.x / 2), 0, 
			//transform.position.z + Random.Range (-transform.localScale.z / 2, transform.localScale.z / 2));

			//}
		}
	}
}
