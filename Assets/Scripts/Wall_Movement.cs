using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Movement : MonoBehaviour {

	Rigidbody myRigidbody;

	public float speed;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody> ();

		Setup ();

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		myRigidbody.velocity = Vector3.left * speed;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.CompareTag("Player"))
		{
			//Dano ao player;

			TurboTunnel_GameManager.instance.DamagePlayer ();
		}

		if(collider.CompareTag("Killzone"))
		{
			//Destroi a wall
			if (GetComponentInParent<DestroyChunk> () != null)
			{
				GetComponentInParent<DestroyChunk> ().ReduceChilds ();
			}
			Destroy(this.gameObject);
		}
	}

	public void Setup()
	{
		speed = speed * TurboTunnel_GameManager.instance.game_speed;
	}
}