using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour 
{


	public float maxEnergy;
	public float currentEnergy;
	public bool dead;
	float timer;

	Slider[] energyBars = new Slider[5];
	Slider []bars;
	int energyBarIndex = 0;
	Slider activeEnergybar;

	public bool useEnergy;
	void Awake () 
	{
		bars = GameObject.FindGameObjectWithTag ("p1NRG").GetComponentsInChildren<Slider> ();

		energyBars [0] = bars[4];
		energyBars [1] = bars[3];
		energyBars [2] = bars[2];
		energyBars [3] = bars[1];
		energyBars [4] = bars[0];

		currentEnergy = maxEnergy;

		activeEnergybar = energyBars[0];

		foreach (Slider h in energyBars) 
		{
			h.value = maxEnergy;
		}


	}

	void Update ()
	{

		Testing ();

		if (energyBarIndex <= energyBars.Length - 1)
		{
			activeEnergybar = energyBars [energyBarIndex];

			activeEnergybar.value = currentEnergy;
		}	
	}

	public void UseEnergy(float amount)
	{
		currentEnergy -= amount;

		if (currentEnergy <= 0) 
		{
			ActivateNextSlider ();
		}

	}

	void ActivateNextSlider()
	{
		if (energyBarIndex < energyBars.Length - 1) 
		{
			energyBarIndex++;
			currentEnergy = maxEnergy;
		}



	}


}