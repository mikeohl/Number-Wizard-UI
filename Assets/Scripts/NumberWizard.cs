// Copyright 2017 Michael J. Ohl
/* NumberWizard class guesses the player's number with a random
 * guess, given player response that guess is higher or lower 
 * than player's number. 
 */

using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    const int MIN_START = 1;    // Hard coded in text on start screen
    const int MAX_START = 1000; // Hard coded in text on start screen

    public Text guessText;   
    public int maxGuessesAllowed = 10;
	
    private LevelManager levelManager;
    private int max, min, guess;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        StartGame();
	}

    void StartGame()
    {
        min = MIN_START;
        max = MAX_START;
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }

    // Guess was too low, guess a higher number
    public void GuessHigher () {	
		min = guess + 1;
		if (min > max) {
			min = max;
		}
		NextGuess();
	}

    // Guess was too high, guess a lower number
    public void GuessLower () {	
		max = guess - 1;
		if (max < min) {
			max = min;
		}
		NextGuess();
	}
	
	// Make a random guess within min, max range until guesses
    // expire. Once guesses expire, player wins
	void NextGuess () {
		guess = Random.Range(min, max + 1);
		guessText.text = guess.ToString();
		maxGuessesAllowed--;
		
		if (maxGuessesAllowed <= 0) {
			levelManager.LoadLevel("Win");
		}
	}
}
