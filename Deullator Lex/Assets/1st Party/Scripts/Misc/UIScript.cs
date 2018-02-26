using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public GameObject youwin;
    public int timeLeft = 300f;

	public text timeLeft

    void Update() {
        timeLeft -= Time.deltaTime;
        timeLeft.text = "300" + timeLeft;
	}
	
    
	
 }
    
 



