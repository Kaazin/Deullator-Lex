using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour 
{
	public AudioMixer mixer;	

	public Slider master;
	public Slider BGM;
	public Slider SFX;
	public Slider voice;

	public void SetMasterVol()
	{
		mixer.SetFloat ("Master", master.value);
	}
	public void SetBGMVol(float vol)
	{
		mixer.SetFloat ("BGM", BGM.value);
	}
	public void SetSFXVol(float vol)
	{
		mixer.SetFloat ("SFX", SFX.value);

	}	public void SetVoiceVol()
	{
		mixer.SetFloat ("Voice", voice.value);
	}

}
