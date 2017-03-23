using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurboTunnel_GameManager : MonoBehaviour {

	[Header("Audio Clips")]
	public AudioClip explosion;
	[Header("Sensors")]
	public Obstacle_Sensor[] sensors;

	private float wait_delay = 4f;
	private float difficultyTimer = 15f;

	public float game_speed = 1f;

	public int player_health = 1;

	public int game_score = 0;

	public static TurboTunnel_GameManager instance;

	private GameObject player;

	private bool generate = false;

	private bool game_active = true;

	// Use this for initialization
	void Awake () {
		instance = this;


	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		StartCoroutine (StartDelay ());
	}
	
	// Update is called once per frame
	void Update () {
		if (game_active)
		{
			if (generate)
			{
				StartCoroutine (CreateNewObstacles ());
			}
		}
	}

	IEnumerator CreateNewObstacles()
	{
		generate = false;

		GameObject[] obstacles = Resources.LoadAll<GameObject> ("Obstacles/");

		int r = Random.Range (0, obstacles.Length);

		GameObject obstacle = Instantiate (obstacles [r]);
		obstacle.GetComponent<NestedPrefab> ().GeneratePrefabs ();

		yield return new WaitForSeconds (wait_delay);

		generate = true;

	}

	public void DamagePlayer()
	{
		player_health--;

		if (player_health <= 0)
		{
			game_active = false;	
			StartCoroutine (Death ());
		}
	}

	IEnumerator Death()
	{
		CheckHighScore ();
		//Colocar animacao de morte
		SoundManager.instance.PlaySingle(explosion, 1);
		Destroy(player);
		yield return new WaitForSeconds (2f);
		SceneManager.LoadSceneAsync ("Game");
	}

	IEnumerator StartDelay()
	{
		yield return new WaitForSeconds (3f);
		generate = true;
		StartCoroutine (AddScore ());
		StartCoroutine (IncreaseSpeed());
	}

	IEnumerator AddScore()
	{
		while (game_active)
		{
			game_score += 100;
			yield return new WaitForSeconds (0.3f);
		}
	}

	IEnumerator IncreaseSpeed()
	{
		while (game_active)
		{
			yield return new WaitForSeconds (difficultyTimer);
			game_speed = game_speed * 1.25f;
			difficultyTimer = difficultyTimer * game_speed;
			wait_delay = wait_delay / game_speed;
			foreach(Obstacle_Sensor sensor in sensors)
			{
				sensor.ChangeSensorDistance ();
			}
		}
	}

	void CheckHighScore ()
	{
		if (game_score > PlayerPrefs.GetInt ("HighScore", 0))
		{
			PlayerPrefs.SetInt ("HighScore", game_score);
		}
	}

}
