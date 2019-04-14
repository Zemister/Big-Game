using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour {

    public VolumeController[] vcObjects;

    public float MaxVolumeLevel = 1.0f;
    public float currentVolume;

	// Use this for initialization
	void Start () {
        vcObjects = FindObjectsOfType<VolumeController>();
        
        if(currentVolume > MaxVolumeLevel)
        {
            currentVolume = MaxVolumeLevel;
        }

        for(int i = 0; i < vcObjects.Length; i++)
        {
            vcObjects[i].SetAudioLevel(currentVolume);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
