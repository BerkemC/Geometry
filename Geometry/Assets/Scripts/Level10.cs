using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Level10 : MonoBehaviour {
	private Text info;
	private float timer = 10f;
	private bool check = false;
	// Use this for initialization
	void Start () {
		info = GameObject.Find ("Info").GetComponent<Text>();
		info.text = "Challange: Find Portal Enterance Before You Die!";
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0f && check == false) {
			info.text = "";
			check = true;
		}
	}
}
