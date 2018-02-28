using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyBar : MonoBehaviour 
{


	public float maxEnergy; //the maximmum energy a player can have
	public float currentEnergy;	//the current energy the player has
	public float multiplier = 10f;
	Slider[] energyBars = new Slider[5]; //an array to reaarange the enrgy bars
	Slider []bars;						// an array to grab the energy bars
	int energyBarIndex = 0;	//the array index of the energy bars
	Slider activeEnergybar;	//the active energy bar
	float combinedEnergy; 	//the starting amount of energy when all of the sliders are added together
	public float currentCombinedEnergy;	//the current amount of energy combined

	void Awake () 
	{
		//set up the references and assign the energy bars to their repsective array elemts
		bars = GameObject.FindGameObjectWithTag ("p1NRG").GetComponentsInChildren<Slider> ();

		energyBars [0] = bars[4];
		energyBars [1] = bars[3];
		energyBars [2] = bars[2];
		energyBars [3] = bars[1];
		energyBars [4] = bars[0];

		//set the current energy to max energy
		currentEnergy = maxEnergy;

		activeEnergybar = energyBars[0];

		//asssign a value to maxEnergy
		foreach (Slider h in energyBars) 
		{
			//set all aof the energy bars' layers to maximum
			h.value = maxEnergy;
		}

		//assign a value to combined energy
		combinedEnergy = bars.Length * maxEnergy;

		currentCombinedEnergy = combinedEnergy;
		Debug.Log (combinedEnergy);

	}

	void Update ()
	{

		//if we are not on the last energy bar...
		if (energyBarIndex <= energyBars.Length - 1)
		{
			// set the current energy bar to the topmost layer
			activeEnergybar = energyBars [energyBarIndex];

			activeEnergybar.value = currentEnergy;
		}	



	}

	public void UseEnergy(float amount)
	{ 
		//subtract the amount from the current energy
		currentEnergy -= amount;
		currentCombinedEnergy -= amount;

		//if there is no energy left on this slider
		if (currentEnergy <= 0) 
		{
			//go to the next slder
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