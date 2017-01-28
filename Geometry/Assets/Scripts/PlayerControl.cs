using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour {
	private float speed = 20f,upSpeed=50f,fastSpeed  = 50f,timer=0f;
	private Text text,scoreText,healthText;
	public static int score = 0;
	private int jumpTime;
	private bool IsJumping = false, IsPlatform = false,IsDownArrow =false,IsFastPlatform = false,IsWin = false;
	private int health = 200;
	private Vector3 temp;
	public AudioClip[] sounds;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		text = GameObject.Find ("Info").GetComponent<Text> ();
		scoreText = GameObject.Find ("Score").GetComponent<Text> ();
		healthText = GameObject.Find ("Health").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(IsWin)timer += Time.deltaTime;
		if(timer >= 25f) {
			GameObject.Find ("Finish").transform.position = new Vector3 (359f,-683.3f,0f);
			text.text = "Just Kidding.";
			timer = 0;
			IsWin = false;
		}
		scoreText.text = "Score: " + score.ToString ();
		healthText.text = "Health: " + health.ToString ();
		if(Input.GetKey(KeyCode.RightArrow)){
			gameObject.transform.position += Vector3.right*speed*Time.deltaTime;
			if(IsFastPlatform)gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(fastSpeed,0f,0f);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			if(!IsFastPlatform)gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
			else gameObject.transform.position += Vector3.left * fastSpeed * Time.deltaTime;
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			gameObject.transform.localScale-= new Vector3(0.5f, 0.5f, 0.5f);
		}
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			gameObject.transform.localScale+= new Vector3(0.5f, 0.5f, 0.5f);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && IsJumping == false) {
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [1];
				SoundPlayer.sounds.Play ();
			}
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f, upSpeed, 0f);
			jumpTime++;
			if (jumpTime == 2)
				IsJumping = true;
			if (transform.parent) {
				if (transform.parent.tag == "Platform") {
					gameObject.transform.parent = null;
				}
			}
		}
		if (IsFastPlatform)
			fastSpeed+=15f*Time.deltaTime;
		else
			fastSpeed = 50f;
	}
		
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Triangle"){
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f,80f,0f);
			jumpTime = 0;
			IsJumping = false;
			GetComponent<AudioSource> ().clip = sounds [3];
			GetComponent<AudioSource> ().Play();
			GetComponent<AudioSource> ().loop = false;
		}
		if (col.gameObject.tag == "Spine"){
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [2];
				SoundPlayer.sounds.Play ();
			}
			if(PlayerPrefsManager.GetHighScore() < score){
				text.text = "New Highest Score!!";
				PlayerPrefsManager.SetNewHighScore (score);
			}
			score = 0;
			Destroy (gameObject);
			text.text = "You Died";
		}
		if(col.gameObject.tag == "End"){
			text.text="You Win!";
			if(PlayerPrefsManager.GetHighScore() < score){
				text.text = "New Highest Score!!";
				PlayerPrefsManager.SetNewHighScore (score);
			}
			PlayerPrefsManager.SetUnlockedLevel (Application.loadedLevel-2);
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [5];
				SoundPlayer.sounds.Play ();
			}
			GameObject.Find("LevelManager").GetComponent<LevelManager>().LoadLevelAfter(2f);
			Destroy (gameObject);

		}
		if(col.gameObject.tag=="Destroyer"){
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [2];
				SoundPlayer.sounds.Play ();
			}
			if(PlayerPrefsManager.GetHighScore() < score){
				text.text = "New Highest Score!!";
				PlayerPrefsManager.SetNewHighScore (score);
			}
			score = 0;
			Destroy (gameObject);
			text.text = "You Died";
		}
		if(col.gameObject.tag =="Platform"){
			jumpTime = 0;
			IsJumping = false;
			gameObject.transform.parent = col.gameObject.transform;
		}
		if(col.gameObject.tag=="Hold"){
			if(Application.loadedLevel == 8)gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (500f,100f,0f);
			if(Application.loadedLevel == 9 )gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (500f,0f,0f);
			if(Application.loadedLevel == 12 )gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector3 (400f,20f,0f);
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [0];
				SoundPlayer.sounds.Play ();
			}
		}
		if(col.gameObject.tag =="FastGround"){
			IsFastPlatform = true;
		}else {
			IsFastPlatform = false;
		}
		if(col.gameObject.tag == "Block"){
			Vector3 NoSpeed = new Vector3(0f,0f,0f);
			gameObject.GetComponent<Rigidbody2D> ().velocity = NoSpeed;
		}

	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Projectile") {
			health -= 25;
			Destroy (col.gameObject);
			if (health <= 0) {
				SoundPlayer.sounds.clip = sounds [2];
				SoundPlayer.sounds.Play ();
				if(PlayerPrefsManager.GetHighScore() < score){
					text.text = "New Highest Score!!";
					PlayerPrefsManager.SetNewHighScore (score);
				}
				score = 0;
				Destroy (gameObject);
				text.text = "You Died";
			}
		}
		if(col.gameObject.tag == "Coin"){
			score += 50;
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [6];
				SoundPlayer.sounds.Play ();
			}
			Destroy (col.gameObject);
		}
		if(col.gameObject.tag=="Teleport"){
			gameObject.transform.position =col.gameObject.transform.FindChild ("Arrive").transform.position;
			if(Application.loadedLevel == 14) {
				text.text = "LOOOOLLL!!";
				IsWin = true;
			}
			if(SoundPlayer.sounds.volume != 0f) {
				SoundPlayer.sounds.clip = sounds [4];
				SoundPlayer.sounds.Play ();
			}
		}
		if(col.gameObject.tag=="TimedTeleport"){
			col.gameObject.GetComponent<Teleport> ().IsStart = true;
			gameObject.transform.position =col.gameObject.transform.FindChild ("Arrive").transform.position;
		}
		if(col.gameObject.tag == "VerticalZeroChange"){
			GameObject.Find ("Main Camera").GetComponent<Camera> ().verticalLimit = 0f;
		}
		if(col.gameObject.tag =="VerticalDefaultChange"){
			GameObject.Find ("Main Camera").GetComponent<Camera> ().verticalLimit = 40f;
		}
	}
}
