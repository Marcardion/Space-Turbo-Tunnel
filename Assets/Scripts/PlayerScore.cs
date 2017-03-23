using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	private Text myText;

	// Use this for initialization
	void Start () {

		myText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		myText.text = "SCORE: " + ReturnZeros() + TurboTunnel_GameManager.instance.game_score;
		
	}

	string ReturnZeros()
	{
		int num_zeros = 6;

		string zero_str = "";

		foreach (char c in TurboTunnel_GameManager.instance.game_score.ToString ())
		{
			num_zeros--;
		}
			
			switch (num_zeros)
			{
				case 5:
					zero_str = "00000";
					break;
				case 4:
				zero_str = "0000";
					break;
				case 3:
				zero_str = "000";
					break;
				case 2:
				zero_str = "00";
					break;
				case 1:
				zero_str = "0";
					break;
			}

		return zero_str;
	}
}
