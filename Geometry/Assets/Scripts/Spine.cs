using UnityEngine;
using System.Collections;

public class Spine : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		if (Application.loadedLevel == 11 && col.gameObject.tag == "Destroyer")
			Destroy (gameObject);
		else if(Application.loadedLevel == 11 && col.gameObject.tag == "Platform")
			Destroy (gameObject);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
