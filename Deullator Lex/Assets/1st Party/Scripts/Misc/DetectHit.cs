using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour 
{
	public float amount;

	void OnTriggerEnter(Collider col)
	{
		PlayerHealth playerHealth = col.GetComponent<PlayerHealth> ();

		if (playerHealth != null)
		playerHealth.TakeDamage(amount);
	}
}
