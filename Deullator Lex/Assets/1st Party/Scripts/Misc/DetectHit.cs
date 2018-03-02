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
	public string name;

	public Rigidbody hitObject;

	public bool hit;

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
		}
	}

	void OnTriggerStay(Collider col)
	{
			PlayerHealth playerHealth = col.GetComponent<PlayerHealth> ();
			if (playerHealth != null) 
			{
				hit = false;
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

	public void AddKnockback(Rigidbody rb, float kb, float launchAngle)
	{ 
		if (hitObject != null) 
		{
			Vector3 dir = Quaternion.AngleAxis (launchAngle, Vector3.forward) * Vector3.right;
			rb.AddForce (dir * kb);
		} 
		else
			return;
	}
}
