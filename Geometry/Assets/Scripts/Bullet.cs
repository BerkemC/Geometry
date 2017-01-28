using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private Vector3 targetPos;
	private float bulletSpeed = 60f;
	private GameObject target;
	private Quaternion tempRotation;
	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Ball");
		if(target) 
			transform.LookAt (target.transform);
			//targetPos = target.transform.position;

		if (Application.loadedLevel == 7)
			bulletSpeed = 70f;
		else if (Application.loadedLevel == 10)
			bulletSpeed = 90f;
	}
	// Update is called once per frame
	void Update () {
		if(target) 
			transform.Translate (Vector3.forward * bulletSpeed * Time.deltaTime);
	}
}
