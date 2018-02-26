using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour 
{


	public float maxValue;

	public float currentValue;

	public float multiplier = 10;
	float timer;



	Slider energyBar;
	public bool isPlayer1 = true; 
	void Awake()
	{
		currentValue = maxValue;

		if (isPlayer1)
			energyBar = GameObject.FindGameObjectWithTag ("p1NRG").GetComponent<Slider> ();

		else
			energyBar = GameObject.FindGameObjectWithTag ("p2NRG").GetComponent<Slider> ();


		energyBar.value = currentValue;

	}

	void Update()
	{
		energyBar.value = currentValue;

		if (currentValue < maxValue) 
		{
			currentValue += Time.deltaTime * multiplier;
		}
			
	}


	public void UseEnergy(float amount)
	{
		currentValue -= amount;
	}
}
