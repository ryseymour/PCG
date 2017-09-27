using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPaint : MonoBehaviour {

	public Renderer rend;
//	public int upPaint;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer> ();
		rend.enabled = true;

		Material upMat = Resources.Load ("Door", typeof(Material)) as Material;
		rend.sharedMaterial = upMat;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
