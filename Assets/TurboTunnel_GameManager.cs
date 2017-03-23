using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurboTunnel_GameManager : MonoBehaviour {

	[Header("Audio Clips")]
	public AudioClip explosion;

	public float wait_delay = 4f;

	public float game_speed = 1f;

	public int player_health = 1;

	public static TurboTunnel_GameManager instance;

	private GameObject player;

	private bool generate = true;

	private bool game_active = true;

	// Use this for initialization
	void Start () {
		instance = this;

		player = GameObject.FindGameObjectWithTag ("Player");
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
		//Colocar animacao de morte
		SoundManager.instance.PlaySingle(explosion, 1);
		Destroy(player);
		yield return new WaitForSeconds (2f);
		SceneManager.LoadSceneAsync ("Game");
	}


}
