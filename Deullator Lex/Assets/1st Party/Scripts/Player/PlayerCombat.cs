using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public float time = 0.5f;

	Animator anim;

	void Awake () 
	{
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{	
		//if Wk button is pessed play set animator state wk to true and start the reset coroutine 
		if (Input.GetButtonDown ("Wk") && Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0) 
		{
			anim.SetBool ("Wk", true);
			StartCoroutine (ResetWk (time));
		}

		//if Str button is pessed play set animator state str to true and start the reset coroutine 

		if (Input.GetButtonDown ("Str") && Input.GetAxis("Horizontal") == 0 &&  Input.GetAxis("Vertical") == 0)
		{
			anim.SetBool ("Str", true);
			StartCoroutine (ResetStr (time));
		}

		//if <eded button is pessed play set animator state str to true and start the reset coroutine 

		if (Input.GetButtonDown ("Med") && Input.GetAxis("Horizontal") == 0 &&  Input.GetAxis("Vertical") == 0)
		{
			anim.SetBool ("Med", true);
			StartCoroutine (ResetMed (time));
		}
		//if Spec button is pessed play set animator state str to true and start the reset coroutine 

		if (Input.GetButtonDown ("Spec") && Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0) {
			anim.SetBool ("Spec", true);
		} 
		else
			anim.SetBool ("Spec", false);
		
		//if any attack button is pressed and horizontal axis is pressed in either direction and vertical axis reads nothing
		if ((Input.GetButtonDown ("Spec") || Input.GetButtonDown ("Wk") || Input.GetButtonDown ("Str") || Input.GetButtonDown ("Med")) && 
			Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") == 0)
		{
			anim.SetBool ("Push", true);
			StartCoroutine (ResetPush (time));
		}
		
		//if any attack button is pressed and Vertical axis is pressed in up and Horizontal axis reads nothing
		if ((Input.GetButtonDown ("Spec") || Input.GetButtonDown ("Wk") || Input.GetButtonDown ("Str") || Input.GetButtonDown ("Med")) && 
			Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") > 0)
		{
			anim.SetBool ("Popup", true);
			StartCoroutine (ResetPopup (time));
		}

		//if any attack button is pressed and Vertical axis is pressed in down and Horizontal axis reads nothing
		if ((Input.GetButtonDown ("Spec") || Input.GetButtonDown ("Wk") || Input.GetButtonDown ("Str") || Input.GetButtonDown ("Med")) && 
			Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") < 0)
		{
			anim.SetBool ("Sweep", true);
			StartCoroutine (ResetSweep (time));
		}

	}

	IEnumerator ResetWk(float time)
	{
		yield return new WaitForSeconds (time);
		anim.SetBool ("Wk", false);	
	}
	IEnumerator ResetMed(float time)
	{
		yield return new WaitForSeconds (time);
		anim.SetBool ("Med", false);	
	}
	IEnumerator ResetStr(float time)
	{
		yield return new WaitForSeconds (time);

		anim.SetBool ("Str", false);	
	}

	IEnumerator ResetSweep(float time)
	{
		yield return new WaitForSeconds (time);

		anim.SetBool ("Sweep", false);	
	}
	IEnumerator ResetPopup(float time)
	{
		yield return new WaitForSeconds (time);

		anim.SetBool ("Popup", false);	
	}
	IEnumerator ResetPush(float time)
	{
		yield return new WaitForSeconds (time);

		anim.SetBool ("Push", false);	
	}

}