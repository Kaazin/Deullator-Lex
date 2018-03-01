using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
	BoxCollider[] Hitboxes;
	int i = 0;

	void Awake()
	{
		Hitboxes = GetComponentsInChildren<BoxCollider> ();

		foreach (BoxCollider h in Hitboxes) 
		{ 
			i++;
			Debug.Log (h.name + " " + i);
		}
	}
	public void EnableHandHitboxR()
	{
		Hitboxes [3].enabled = true;
	}
	public void DisbleHandHitboxR()
	{
		Hitboxes [3].enabled = false;
	}
	public void EnableHandHitboxL()
	{
		Hitboxes [2].enabled = true;
	}
	public void DisbleHandHitboxL()
	{
		Hitboxes [2].enabled = false;
	}
	public void EnableFootHitboxR()
	{
		Hitboxes [0].enabled = true;
	}
	public void DisbleFootHitboxR()
	{
		Hitboxes [0].enabled = false;
	}
	public void EnableFootHitboxL()
	{
		Hitboxes [1].enabled = true;
	}
	public void DisbleFootHitboxL()
	{
		Hitboxes [1].enabled = false;
	}

}
