using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Projectile")
			Destroy (col.gameObject);
		
	}
	void OnCollisionEnter2D(Collision2D col){
		if (Application.loadedLevel == 11 && col.gameObject.tag == "Spine")
			Destroy (col.gameObject);
	}

}
