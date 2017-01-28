using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public float SpawnTime = 10f;
	public bool IsStart = false;
	private Vector3 givenTransform;
	void Start(){
		givenTransform = transform.position;
		givenTransform.y += 20f;
	}
	// Update is called once per frame
	void Update () {
		
		if (IsStart) {
			SpawnTime -= Time.deltaTime;
		}
		if (SpawnTime <= 0f) {
			transform.FindChild ("Arrive").transform.position = givenTransform;
			IsStart = false;
		}
	}
}
