using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	public static AudioSource sounds;
	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(gameObject);
		sounds = GetComponent<AudioSource> ();
	}

	public void MuteSound(){
		if (GameObject.Find("SoundPlayer").GetComponent<AudioSource>().volume != 0f)
			GameObject.Find("SoundPlayer").GetComponent<AudioSource>().volume=0f;
		else
			GameObject.Find("SoundPlayer").GetComponent<AudioSource>().volume= 1f;
	}
}
