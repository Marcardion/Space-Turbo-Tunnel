using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChunk : MonoBehaviour {

	public int childNumber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReduceChilds()
	{
		childNumber -= 1;

		if (childNumber <= 0)
		{
			Destroy (this.gameObject);	
		}
	}
}
