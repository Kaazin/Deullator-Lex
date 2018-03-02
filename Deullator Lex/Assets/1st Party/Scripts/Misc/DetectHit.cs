using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour 
{
	public float amount;
	public float sweepAngle;
	public float popupAngle;
	public float pushAngle;
	public float sweepKb;
	public float popupKb;
	public float pushKb;

	bool addedForce = false;
	public string name;

	GameObject root;
	Animator anim;
	public Rigidbody hitObject;

	public bool hit;

	void Awake()
	{
		root = transform.root.gameObject;
		anim = root.GetComponentInChildren<Animator> ();
	}

	void OnTriggerEnter(Collider col)
	{
		PlayerHealth playerHealth = col.GetComponent<PlayerHealth> ();
		if (playerHealth != null)
		{
			hitObject = col.gameObject.GetComponent<Rigidbody>();
			Debug.Log ("Hit");
			Debug.Log (col.transform.root.name);
			playerHealth.TakeDamage (amount);
			hit = true;

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Popup") && !addedForce)
			{
				Debug.Log ("popup");
				AddKnockback (col.GetComponent<Rigidbody> (), popupKb, popupAngle, Vector3.right);
				addedForce = true;
				addedForce = false;
			}

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Sweep") && !addedForce)
			{
				Debug.Log ("Sweep");
				AddKnockback (col.GetComponent<Rigidbody> (), sweepKb, sweepAngle, Vector3.right);
				addedForce = true;
				addedForce = false;
			}

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push") && !addedForce)
			{
				Debug.Log ("Push");
				AddKnockback (col.GetComponent<Rigidbody> (), pushKb, pushAngle, -Vector3.forward);
				addedForce = true;
				addedForce = false;
			}

		}
	}

	void OnTriggerStay(Collider col)
	{
			PlayerHealth playerHealth = col.GetComponent<PlayerHealth> ();
			if (playerHealth != null) 
			{

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Popup") && !addedForce)
			{
				Debug.Log ("popup");
				AddKnockback (col.GetComponent<Rigidbody> (), popupKb, popupAngle, Vector3.right);
				addedForce = true;		
				addedForce = false;
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Sweep") && !addedForce) 
			{
				Debug.Log ("Sweep");
				AddKnockback (col.GetComponent<Rigidbody> (), sweepKb, sweepAngle, Vector3.right);
				addedForce = true;
				addedForce = false;
			}

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Push") && !addedForce)
			{
				Debug.Log ("Push");
				AddKnockback (col.GetComponent<Rigidbody> (), pushKb, pushAngle, -Vector3.forward);
				addedForce = true;
				addedForce = false;
			}

		}



		}
		


	void OnTriggerExit(Collider col)
	{
		PlayerHealth playerHealth = col.GetComponent<PlayerHealth> ();
		if (playerHealth != null) 
		{
			hit = false;
		}
	}

	public void AddKnockback(Rigidbody rb, float kb, float launchAngle, Vector3 velocity)
	{ 
		if (hitObject != null) 
		{
			Vector3 dir = Quaternion.AngleAxis (launchAngle, Vector3.forward) * velocity;
			rb.velocity = dir * kb;
		} 
		else
			return;
	}
}
