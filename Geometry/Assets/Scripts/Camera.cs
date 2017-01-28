using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	private GameObject target;
	private Vector3 temp,tempscale;
	private float tempy;
	private Quaternion temptransform;


	public float verticalLimit,upLimit,downLimit;


	void Start(){
		target = GameObject.Find ("Ball");
		if (Application.loadedLevel == 3) {
			verticalLimit = 20f;
			upLimit = 30f;
			downLimit = 20f;
		} else if (Application.loadedLevel == 4) {
			verticalLimit = 30f;
			upLimit = 30f;
			downLimit = 20f;
		} else if (Application.loadedLevel >= 5) {
			if (Application.loadedLevel == 9)
				verticalLimit = 30f;
			else if (Application.loadedLevel == 12)
				verticalLimit = 30f;
			else if (Application.loadedLevel == 10) {
				
				verticalLimit = 0f;
			}
			else if(Application.loadedLevel == 12) {
				
				verticalLimit = 0f;
			}
			else if (Application.loadedLevel == 13 ||Application.loadedLevel == 14 )
				
				verticalLimit = 0f;
			else
				verticalLimit = 40f;

			upLimit = 10f;
			downLimit = 5f;
			if (Application.loadedLevel == 14)
				upLimit = 0f;
		}
		temp = transform.position;
		tempy=target.transform.position.y;
		temp.y = target.transform.position.y;
		if (Application.loadedLevel == 10)
			temp.z = -96;
		else if(Application.loadedLevel == 13)
			temp.z = -96;
		temptransform = target.transform.rotation;
		tempscale = transform.localScale;
	}
	void Update(){
		if (target) {
			temp.x = target.transform.position.x + verticalLimit;
			transform.position = temp;
			transform.rotation = temptransform;
			transform.localScale = tempscale;
			if (target.transform.position.y >= temp.y + upLimit)
				temp.y += 30f * Time.deltaTime;//target.transform.position.y-downLimit;
			if(target.transform.position.y <= temp.y -downLimit)
				temp.y -= 75f * Time.deltaTime; //target.transform.position.y+downLimit;
		}
	}
}
