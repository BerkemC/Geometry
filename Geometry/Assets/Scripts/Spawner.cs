using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Spawner : MonoBehaviour {
	public GameObject finish;
	private Text info;
	private float time = 120f;
	// Use this for initialization
	void Start () {
		
		info = GameObject.Find ("Info").GetComponent<Text> ();
		info.text = "Challange: Survive the siege for 2 minutes!";
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0f) {
			info.text = "Find Exit!";
			finish.SetActive (true);
		}
		if (time <= 110f && GameObject.Find("Ball"))
			info.text = time.ToString();
	}
}
