using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//brings in user interface

public class TextScript : MonoBehaviour {

	private enum States{
		cell,
		mirror,
		sheets_0,
		lock_0,
		cell_mirror,
		sheets_1,
		lock_1,
		freedom,
		exit
	}

	private States myState;

	public Text text;

	private Input key;

	// Use this for initialization
	void Start () {
		myState = States.cell;
		print (myState); // prints the state in the console.
	}
	
	// Update is called once per frame
	void Update () {

		//start
		if (myState == States.cell) {
			state_cell ();
		} else if (myState == States.mirror) {
			mirror ();
		} else if (myState == States.lock_0) {
			lock_0 ();
		} else if (myState == States.sheets_0) {
			sheets_0 ();
		} else if (myState == States.cell_mirror) {
			cell_mirror ();
		} else if (myState == States.sheets_1) {
			sheets_1 ();
		} else if (myState == States.lock_1) {
			lock_1 ();
		} else if (myState == States.freedom) {
			Freedom ();
		} else if (myState == States.exit) {
			exit ();
		}

	}

	void state_cell(){
		text.text = "You are in a prison cell, an you want to escape. There are " +
			"some dirty sheets on the bed, a mirror on the wall, and the door " +
			"is locked from the outside.\n\n" + 
			"Press S to view sheets, \n" + 
			"Press M to view mirror, \n" + 
			"and press L to view lock.\n"+
			"Or press R to return to the beginning.";
		if (Input.GetKeyDown (KeyCode.M)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			myState = States.lock_0;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			myState = States.sheets_0;
		}
	}

	void mirror(){
		myState = States.mirror;
		text.text = "You are now looking at the mirror and do you wish to take the cell mirror?" +
			" Or do you wish to return back to cell?\n\n" + 
			"Press T to take the cell mirror\n" + 
			"Press R to return back to cell state";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			myState = States.cell_mirror;
		}

	}

	void sheets_0(){
		myState = States.sheets_0;
		text.text = "I can't believe you actually sleep in these sheets..." +
		" Lets examine if these sheets have anything hidden in it.\n" + 
		"Press R to return back to the cell";
		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void lock_0(){
		myState = States.lock_0;
		text.text = "There is an old and rusted lock. Do you want to try to unlock it?\n\n" +
		"Press R to return.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell;
		}
	}

	void sheets_1(){
		text.text = "There is nothing much to these sheets either.\n" +
		"Press R to return back to the cell mirror state.";

		if (Input.GetKeyDown (KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void cell_mirror(){
		text.text = "From this cell mirror, do you want to\n\n" +
		"Press P to check out the sheets 1\n" +
		"Press A to check out Lock 1 \n" +
		"Press R to return back to mirror state";

		if (Input.GetKeyDown (KeyCode.A)) {
			myState = States.lock_1;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			myState = States.sheets_1;
		}
	}

	void lock_1(){
		text.text = "This lock looks like it's easy to open\n" +
		"Press F to try to open it";

		if (Input.GetKeyDown (KeyCode.F)) {
			myState = States.freedom;
		}
	}

	void Freedom(){
		text.text = "Yay! You've escaped\n"+
			"Do you wish to continue? (Y/N)";

		if (Input.GetKeyDown (KeyCode.Y)) {
			myState = States.cell;
		}

		if (Input.GetKey (KeyCode.N)) {
			myState = States.exit;
		}
	}

	void exit(){
		Application.Quit ();
	}
}
