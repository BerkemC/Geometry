using UnityEngine;
using System.Collections;

public class Spawner11 : MonoBehaviour {
	public GameObject spine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.value < 0.10f*Time.deltaTime){
			GameObject Spine = Instantiate (spine, transform.position, Quaternion.identity) as GameObject;
			Spine.transform.localScale = new Vector3 (Random.Range(0.4f,1f), Random.Range(0.4f,1f), 0f);
			Spine.GetComponent<Rigidbody2D> ().isKinematic = false;
			Spine.GetComponent<Rigidbody2D> ().gravityScale = 0.08f;
			Spine.transform.parent = GameObject.Find ("Spines").transform;
		}
	}
}
