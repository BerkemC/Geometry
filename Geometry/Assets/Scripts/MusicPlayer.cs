using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour {
	public static MusicPlayer instance=null;
	// Use this for initialization
	void Awake(){
		
		if(instance){
			Destroy(gameObject);
		}
		else{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	void Start(){
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = "Current Highest Score: "+ PlayerPrefsManager.GetHighScore ().ToString();
	}
	public void MuteMusic(){
		if (GameObject.Find ("MusicPlayer").GetComponent<AudioSource> ().volume != 0f)
			GameObject.Find ("MusicPlayer").GetComponent<AudioSource> ().volume = 0f;
		else
			GameObject.Find ("MusicPlayer").GetComponent<AudioSource> ().volume = 0.5f;
	}
}
