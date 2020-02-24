using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SonicBloom.Koreo;

public class MyPause : MonoBehaviour {
    public GameObject audioPlayer;
    private AudioSource audio;
    private Canvas canvas;
	// Use this for initialization
	void Start () {
        audio = audioPlayer.GetComponent<AudioSource>();
        canvas = GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))//按ESC键暂停游戏
        {
           
            Pause();                         //暂停
        }
    }

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;//使用timescale暂停，控制游戏
        if (Time.timeScale == 0)
        {
            canvas.enabled = !canvas.enabled;        //画布on stage！
            audio.Pause();
        }//暂停声音
        else
        {
            canvas.enabled = !canvas.enabled;        //画布cast off!
            audio.Play();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(1);                   //重新选曲
    }
}
