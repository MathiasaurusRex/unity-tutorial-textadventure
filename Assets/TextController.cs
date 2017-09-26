using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States
	{
		cell,
		mirror,
		sheets_0,
		lock_0,
		cell_mirror,
		sheets_1,
		lock_1,
		cell_mirror_wrapped,
		lock_1_wrapped,
		freedom,
		freedom_death
	}

	private States myState;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print ( myState );
		if ( myState == States.cell) { state_cell();}
		else if ( myState == States.sheets_0)				{state_sheets_0();}

		else if ( myState == States.lock_0)					{state_lock_0();}

		else if ( myState == States.mirror)					{state_mirror();}

		else if ( myState == States.lock_1)					{state_lock_1();}

		else if ( myState == States.lock_1_wrapped)			{state_lock_1_wrapped();}

		else if ( myState == States.sheets_1)				{state_sheets_1();}

		else if ( myState == States.cell_mirror)			{state_cell_mirror();}

		else if ( myState == States.cell_mirror_wrapped)	{state_cell_mirror_wrapped();}

		else if ( myState == States.freedom)				{state_freedom();}

		else if ( myState == States.freedom_death)			{state_freedom_death();}
	}

	void state_cell() {
		text.text = "You are a prison cell, and you want to escape. There are some dirty sheets on the bed, a mirror on the wall, and the door is locked from the outside.\n\n Press S to View Sheets, M to View Mirror and L to view Lock.";
		
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		}
		else if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		}

		else if (Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		}
	}

	void state_cell_mirror() {
		text.text = "Your hands are a bit bloody from shattering the mirror. There are some dirty sheets on the bed and the door is locked from the outside.\n\n Press S to View Sheets and L to view Lock.";
		
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_1;
		}
		else if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1;
		}
	}

	void state_cell_mirror_wrapped() {
		text.text = "The blood has stopped, but the door is still locked from the outside.\n\n  L to view Lock.";
		
		if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1_wrapped;
		}
	}

	void state_sheets_0() {
		text.text = "You take a look at the dirty sheets. They're dirty. \n\n Press R to return to your cell.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}

	void state_lock_0() {
		text.text = "The lock looks like it could be picked with something. \n\n Press R to return to your cell.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}

	void state_sheets_1() {
		text.text = "You take a look at the dirty sheets. They're dirty, but you could use them to stop the flow of blood. \n\n Press R to return to your cell. Press W to wrap your hands.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		}
		else if (Input.GetKeyDown(KeyCode.W)){
			myState = States.cell_mirror_wrapped;
		}
	}

	void state_lock_1() {
		text.text = "The lock looks like it could be picked with something. \n\n Press R to return to your cell. Press P to pick the lock with the shard of glass.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror;
		}
		else if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.freedom_death;
		}
	}

	void state_lock_1_wrapped() {
		text.text = "The lock looks like it could be picked with something. \n\n Press R to return to your cell. Press P to pick the lock with the shard of glass.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_mirror_wrapped;
		}
		else if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.freedom;
		}
	}

	void state_freedom(){
		text.text = "You make it to freedom, but you feel a little whoozy.\n\n Press Return to Restart";
		if (Input.GetKeyDown(KeyCode.Return)){
			myState = States.cell;
		}
	}
	void state_freedom_death(){
		text.text = "You pass out near the fence of the prison. You've lost too much blood. \n\n Press Return to Restart";
		if (Input.GetKeyDown(KeyCode.Return)){
			myState = States.cell;
		}
	}


	void state_mirror() {
		text.text = "The mirror looks like it could be broken into key-like shards.. \n\n Press R to return to your cell. Press S to shatter the mirror.";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
		else if (Input.GetKeyDown(KeyCode.S)){
			myState = States.cell_mirror;
		}
	}
}
