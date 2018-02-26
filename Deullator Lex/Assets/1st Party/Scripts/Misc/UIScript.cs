using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
	//you had timeLeft as the name of both the int and text variable and so I put an underscore on the int one to take away the error :)
    public GameObject youwin;

	//in order to subtract Time.deltaTime your variable needs to be a float
	public float _timeLeft = 300f;

	public Text timeLeft;

    void Update() {
        _timeLeft -= Time.deltaTime;
        timeLeft.text = "300" + timeLeft;
	}
	
    
	
 }
    
 



