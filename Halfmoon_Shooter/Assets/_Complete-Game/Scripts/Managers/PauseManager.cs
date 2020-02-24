using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	
	Canvas canvas;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))//按ESC键暂停游戏
		{
			canvas.enabled = !canvas.enabled;//启用画布
			Pause();                         //暂停
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;//暂停的时间
		Lowpass ();
		
	}
	
	void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			paused.TransitionTo(.01f);
		}
		
		else
			
		{
			unpaused.TransitionTo(.01f);
		}
	}
	
	public void ReturnToMenu()
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
