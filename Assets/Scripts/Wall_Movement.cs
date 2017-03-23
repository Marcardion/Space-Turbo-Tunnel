using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Movement : MonoBehaviour {

	Rigidbody myRigidbody;

	public float speed;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody> ();
		
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
				Debug.Log("Dano");
				TurboTunnel_GameManager.instance.DamagePlayer ();
			}

		if(collider.CompareTag("Killzone"))
		{
			//Destroi a wall
			Debug.Log("Destroy");
			Destroy(this.gameObject);
		}
	}

	public void Setup(float newSpeed)
	{
		speed = newSpeed;
	}
}
