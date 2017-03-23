using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Sensor : MonoBehaviour {

	Animator myAnim;

	private bool active = false;

	public float sensorDistance = 45f;

	// Use this for initialization
	void Start () {

		myAnim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		CheckWall ();
	}

	void CheckWall()
	{
		RaycastHit hit;

		Debug.DrawRay (transform.position, transform.right * sensorDistance, Color.red);

		if (Physics.Raycast (transform.position, transform.right, out hit, sensorDistance))
		{
			if (active == false)
			{
				if (hit.collider.CompareTag ("Wall"))
				{
					myAnim.SetTrigger ("Wall");
					active = true;
				}
			}


		} else
		{
			active = false;
		}
	}

	public void ChangeSensorDistance (float newDistance)
	{
		sensorDistance = newDistance;
	}
}
