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


	public bool useEnergy;

	Slider[] energyBar;
	public bool isPlayer1 = true; 

	//Animator anim;

	public int energyBarIndex = 0;
	Slider activeEnergyBar;
	Transform p2;
	int i = 0;

	void Awake()
	{
		currentValue = maxValue;

		if (isPlayer1)
			energyBar = GameObject.FindGameObjectWithTag ("p1NRG").GetComponentsInChildren<Slider> ();

		else
			energyBar = GameObject.FindGameObjectWithTag ("p2NRG").GetComponentsInChildren<Slider> ();

		activeEnergyBar = energyBar [energyBarIndex];

		//for each slider in energy bar....
		foreach (Slider h in energyBar) 
		{
			//increment i
			i++;

			//if I is less than the health bar index
			if (i <= energyBarIndex)
				//set the value of h to maxValue
				h.value = maxValue;


		}
	}

	void Update()
	{
		if (energyBarIndex <= energyBar.Length - 1)
		{
			activeEnergyBar = energyBar [energyBarIndex];

			activeEnergyBar.value = currentValue; 
		}	
	
		activeEnergyBar.value = currentValue;

		if (currentValue < maxValue) 
		{
			currentValue += Time.deltaTime * multiplier;
		}

		if (activeEnergyBar.value <= 0)
			DestroySlider ();
		if (Input.GetKeyDown (KeyCode.E))
			useEnergy = !useEnergy;

		if (useEnergy)
			UseEnergy (20 * Time.deltaTime);

			
	}


	public void UseEnergy(float amount)
	{
		currentValue -= amount;
	}

	void DestroySlider()
	{


		//if the current energybar is less than the amount of energy bars we have
		if 	(energyBarIndex < energyBar.Length - 1)
		{

			//increment the energybar index
			energyBarIndex++;

			//set current Energy to max Energy
			currentValue = maxValue;
		}



	}
}
