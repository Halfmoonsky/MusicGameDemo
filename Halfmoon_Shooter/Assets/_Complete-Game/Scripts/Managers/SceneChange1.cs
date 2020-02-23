using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneSwitch();
        }
    }

    private void SceneSwitch()
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
