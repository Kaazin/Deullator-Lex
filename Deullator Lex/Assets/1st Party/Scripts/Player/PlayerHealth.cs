using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
	public float maxHealth = 100f;
	public float currentHealth;
	public float time;
	Slider[] healthBar;	//the main health bar

	public bool takeDamage;
	public bool isPlayer1;
	void Awake ()
	{
		currentHealth = maxHealth;

		//set up the references
		if(isPlayer1)
		healthBar = GameObject.Find("p1HealthBar").GetComponentsInChildren<Slider>();
		else
		healthBar = GameObject.Find("p2HealthBar").GetComponentsInChildren<Slider>();


	}
		
	public void TakeDamage(float amount)
	{
		currentHealth -= amount;

		healthBar [1].value = currentHealth;

		StopCoroutine (ResidualHealth ());
		StartCoroutine (ResidualHealth ());

		if (currentHealth <= 0) 
		{
			Death ();
		}
		
	}

	void Death()
	{
		Debug.Log (this.gameObject.name + " " + "Dead");
	}

	IEnumerator ResidualHealth()
	{
		yield return new WaitForSeconds (3);
		healthBar [0].value = Mathf.Lerp (healthBar [0].value, currentHealth, Time.deltaTime * time);
	}

}

