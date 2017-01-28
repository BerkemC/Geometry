using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject projectile;
	private float freq = 0.5f;
	private GameObject Projectiles;
	public AudioClip sound;
	void Start(){
		Projectiles = new GameObject("Enemy Projectiles");
	}
	// Update is called once per frame
	void Update () {
		if (Random.value < freq * Time.deltaTime) {
			if (GameObject.Find("Ball")){
				if(GameObject.Find("Ball").transform.parent!=null) {
						GameObject project = Instantiate (projectile, gameObject.transform.position, Quaternion.identity) as GameObject;
						project.transform.parent = GameObject.Find ("Enemy Projectiles").transform;
						SoundPlayer.sounds.clip = sound;
						SoundPlayer.sounds.Play ();
						}
				}
			}
		}
}
