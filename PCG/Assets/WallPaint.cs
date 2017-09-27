using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPaint : MonoBehaviour {
	public Renderer rend;
	public int wallPaint;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		applyPaint ();
	}

	// Update is called once per frame
	void applyPaint () {
		//Debug.Log (House.wallPaint);
		if (wallPaint == 1) {
			Material newMat = Resources.Load ("Blue", typeof(Material)) as Material;
			rend.sharedMaterial = newMat;
		} else if (wallPaint == 2) {
			Material newMat = Resources.Load ("Red", typeof(Material)) as Material;
			rend.sharedMaterial = newMat;
		}
			else if (wallPaint ==3){
				Material newMat = Resources.Load ("Blue", typeof(Material)) as Material;
				rend.sharedMaterial = newMat;

			}
		else if (wallPaint ==4){
			Material newMat = Resources.Load ("Red", typeof(Material)) as Material;
			rend.sharedMaterial = newMat;

		}
	}
}
