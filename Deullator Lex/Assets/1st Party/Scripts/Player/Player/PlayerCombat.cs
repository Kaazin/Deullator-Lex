using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	Animator anim;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{	
		//if punch wk button is pessed play punch wk animation otherwise go back to idle
		if (Input.GetButtonDown ("Punch Wk") && Input.GetAxis("Horizontal") == 0  && Input.GetAxis("Vertical") == 0)
			anim.SetBool ("Punch Wk", true);
		else
			anim.SetBool ("Punch Wk", false);

		//if punch str button is pessed play punch str animation otherwise go back to idle

		if (Input.GetButtonDown ("Punch Str") && Input.GetAxis("Horizontal") == 0 &&  Input.GetAxis("Vertical") == 0)
			anim.SetBool ("Punch Str", true);
		else
			anim.SetBool ("Punch Str", false);

		//if kick wk button is pessed play kick wk animation otherwise go back to idle

		if (Input.GetButtonDown ("Kick Wk") && Input.GetAxis("Horizontal") == 0 &&  Input.GetAxis("Vertical") == 0)
			anim.SetBool ("Kick Wk", true);
		else
			anim.SetBool ("Kick Wk", false);

		//if kick Str button is pessed play kick Str animation otherwise go back to idle

		if (Input.GetButtonDown ("Kick Str") && Input.GetAxis("Horizontal") == 0 &&  Input.GetAxis("Vertical") == 0)
			anim.SetBool ("Kick Str", true);
		else
			anim.SetBool ("Kick Str", false);

		//if any attack button is pressed and horizontal axis is pressed in either direction and vertical axis reads nothing
		if ((Input.GetButtonDown ("Kick Str") || Input.GetButtonDown ("Kick Wk") || Input.GetButtonDown ("Punch Str") || Input.GetButtonDown ("Punch Wk") ) && 
			Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0)
			anim.SetBool ("Push", true);
		else
			anim.SetBool ("Push", false);
		
		//if any attack button is pressed and Vertical axis is pressed in up and Horizontal axis reads nothing
		if ((Input.GetButtonDown ("Kick Str") || Input.GetButtonDown ("Kick Wk") || Input.GetButtonDown ("Punch Str") || Input.GetButtonDown ("Punch Wk") ) && 
			Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") > 0)
			anim.SetBool ("Popup", true);
		else
			anim.SetBool ("Popup", false);

		//if any attack button is pressed and Vertical axis is pressed in down and Horizontal axis reads nothing
		if ((Input.GetButtonDown ("Kick Str") || Input.GetButtonDown ("Kick Wk") || Input.GetButtonDown ("Punch Str") || Input.GetButtonDown ("Punch Wk") ) && 
			Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") < 0)
			anim.SetBool ("Sweep", true);
		else
			anim.SetBool ("Sweep", false);

	}




}