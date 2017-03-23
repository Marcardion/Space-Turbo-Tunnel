using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	private Text myText;

	// Use this for initialization
	void Start () {

		myText = GetComponent<Text> ();

		myText.text = "HIGHSCORE: " + PlayerPrefs.GetInt ("HighScore", 0);
	}
		
}
