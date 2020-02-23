using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class LightControl : MonoBehaviour {
    public string eventID;
    private Light spotLight;
	// Use this for initialization
	void Start () {
        spotLight = GetComponent<Light>();
      //  spotLight.enabled = false;
        Koreographer.Instance.RegisterForEvents(eventID,ShingingLight);
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void ShingingLight(KoreographyEvent koreographyEvent)
    {
        if (spotLight.enabled)
        {
            spotLight.enabled = false;
        }
        else 
        {
            spotLight.enabled = true;
        }
    }
}
