using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Sensor : MonoBehaviour {

	Animator myAnim;

	private bool active = false;

	public float sensorDistance = 45f;

	public string myObstacle = "";

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



		if (Physics.Raycast (transform.position, transform.right, out hit, sensorDistance))
		{
			if (active == false)
			{
				if (hit.collider.CompareTag (myObstacle))
				{
					myAnim.SetTrigger ("Flash");
					active = true;
				}
			}


		} else
		{
			active = false;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.right * sensorDistance);
	}

	public void ChangeSensorDistance ()
	{
		sensorDistance = sensorDistance * TurboTunnel_GameManager.instance.game_speed;

		if (sensorDistance >= 80) 
		{
			sensorDistance = 80;
		}
		myAnim.SetFloat ("Speed", TurboTunnel_GameManager.instance.game_speed);
	}
}
