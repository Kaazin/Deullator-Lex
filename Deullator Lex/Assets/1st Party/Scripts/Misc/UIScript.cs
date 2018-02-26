using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
	//you had timeLeft as the name of both the int and text variable and so I put an underscore on the int one to take away the error :)

    public GameObject youwin;

	//in order to subtract Time.deltaTime your variable needs to be a float
	public float _timeLeft = 99f;

	float roundTimeLeft;

	public Text timeLeft;

	public float startDelay; //the delay for the timer to start
	public float delayTimer;// how much time has passed befor the delay has started

    void Update() 
	{
		roundTimeLeft = Mathf.Round (_timeLeft);
		//start the delay timer
		delayTimer += Time.deltaTime;
		//if the delay timer has exceeded the start delay
		if (delayTimer >= startDelay && _timeLeft > 0) 
		{
			
			//start the timer
			_timeLeft -= Time.deltaTime;
		
			//set the time string to the current time left
			timeLeft.text = roundTimeLeft.ToString ();
		} 


	}
}
    
 



