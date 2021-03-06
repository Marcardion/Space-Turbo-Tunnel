﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Movement : MonoBehaviour {

	Rigidbody myRigidbody;

	public bool active = true;
	public GameObject ship_model;

	public float speed;

	private bool isGrounded;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		myRigidbody.velocity = new Vector3 (moveHorizontal * speed, myRigidbody.velocity.y, moveVertical * speed);

		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, -10.49f, 11.75f),
			transform.position.y,
			Mathf.Clamp (transform.position.z, -3.3f, 8.7f));


	}

	void Update()
	{
		CheckJump ();
	}

	void CheckJump()
	{
		if (Input.GetButtonDown ("Jump") && isGrounded)
		{
			myRigidbody.AddForce (Vector3.up * 500f);
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.CompareTag("Ground"))
			{
				isGrounded = true;
			}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.CompareTag("Ground"))
		{
			isGrounded = false;
		}
	}

	public void DestroyShip()
	{
		Destroy (ship_model);
	}

}
