using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour 
{
	public float amount;

	public string name;
		
	void OnTriggerEnter(Collider col)
	{
		PlayerHealth playerHealth = col.GetComponent<PlayerHealth> ();
		if (playerHealth != null) 
		{
			Debug.Log ("Hit");
			Debug.Log (col.transform.root.name);
			playerHealth.TakeDamage (amount);

		}
	}
}
