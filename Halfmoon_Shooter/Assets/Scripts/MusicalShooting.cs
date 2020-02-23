using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using CompleteProject;

public class MusicalShooting : MonoBehaviour {
    public string eventID;
    private CompleteProject.PlayerShooting playerShooting;
	// Use this for initialization
	void Start () {
        playerShooting=GetComponent<CompleteProject.PlayerShooting>();
        Debug.Log("register");
        Koreographer.Instance.RegisterForEvents(eventID, PlayerCanShoot);
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void PlayerCanShoot(KoreographyEvent koreographyEvent)
    {
        Debug.Log("can");
        if (Input.GetButton("Fire1"))
        {
            Debug.Log("shoot");
            playerShooting.Shoot();
        }
    }
}
