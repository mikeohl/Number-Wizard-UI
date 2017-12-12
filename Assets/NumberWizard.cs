// Copyright 2017 Michael J. Ohl
// https://gamebucket.io/game/48893ae6-20ac-422d-9c1e-a3a84e7576d4 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	
	public int maxGuessesAllowed = 50;
	public Text text; 

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log ("Up arrow was pressed");
			GuessHigher();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Debug.Log ("Down arrow was pressed");
			GuessLower();
		}
	}
	
	public void GuessHigher () {	
		min = guess + 1;
		if (min > max) {
			min = max;
		}
		NextGuess();
	}
	
	public void GuessLower () {	
		max = guess - 1;
		if (max < min) {
			max = min;
		}
		NextGuess();
	}
	
	void StartGame () {
		max = 1000;
		min = 1;
		guess = Random.Range(min, max + 1);
		text.text = guess.ToString();
	}
	
	void NextGuess () {
		guess = Random.Range(min, max + 1);
		text.text = guess.ToString();
		maxGuessesAllowed--;
		
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}
	}
}
