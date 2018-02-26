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
		if (Input.GetButtonDown ("Punch Wk"))
			anim.SetBool ("Punch Wk", true);
		else
			anim.SetBool ("Punch Wk", false);

		if (Input.GetButtonDown ("Punch Str"))
			anim.SetBool ("Punch Str", true);
		else
			anim.SetBool ("Punch Str", false);

		if (Input.GetButtonDown ("Kick Wk"))
			anim.SetBool ("Kick Wk", true);
		else
			anim.SetBool ("Kick Wk", false);

		if (Input.GetButtonDown ("Kick Str"))
			anim.SetBool ("Kick Str", true);
		else
			anim.SetBool ("Kick Str", false);
		
	}




}