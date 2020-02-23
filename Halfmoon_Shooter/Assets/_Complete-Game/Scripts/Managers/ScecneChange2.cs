using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScecneChange2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SceneSwitch()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("ChooseSong");
        yield return new WaitForEndOfFrame();
        ao.allowSceneActivation = true;
    }
}
