using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectControl : MonoBehaviour {                                    //歌曲选择界面的控制脚本
    public Sprite[] songImages;                                                 //歌曲封面图列表
    public AudioClip[] songs;                                                   //歌单
    private Image img;                                                          //显示封面的UI
    private AudioSource audio;                                                  //音频播放器
    private int next;                                                           //下一曲编号
    private int last;                                                           //上一曲编号
    private void Awake()
    {
        next = 1;                                                 //初始化下一曲上一曲编号
        last = songImages.Length-2;
        img = GetComponentInChildren<Image>();                    //实例化歌单和封面列表并展示第一首歌
        img.sprite = songImages[0];
        audio = GetComponentInChildren<AudioSource>();
        audio.clip = songs[0];
        audio.Play();
    }
    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
    public void NextSong()
    {
        img.sprite = songImages[next];                            //实现切换下一曲单击事件，下一个函数是实现上一曲单击事件
        audio.clip = songs[next];                                 //简单的单击实现的数组遍历
        audio.Play();
        if (next < songImages.Length-1)
            next++;
        else next = 0;
    }

    public void LastSong()
    {
        img.sprite = songImages[last];                            
        audio.clip = songs[last];
        audio.Play();
        if (last > 0)
            last--;
        else last = songImages.Length - 1;
    }

    public void EnterGameScene()                                                    //play按钮的切换场景事件
    {
        if(img.sprite == songImages[0])
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("GameScene");
        yield return new WaitForEndOfFrame();
        ao.allowSceneActivation = true;
    }

}
