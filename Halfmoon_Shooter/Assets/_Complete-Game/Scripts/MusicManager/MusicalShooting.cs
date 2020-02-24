using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;
using CompleteProject;

public class MusicalShooting : MonoBehaviour {                                         //核心玩法，随音乐节奏射击脚本
    public string eventID;                                                            //音轨绑定事件的ID
    private CompleteProject.PlayerShooting playerShooting;                            //需要用到PlayerShooting中的射击函数
   // KoreographyEvent curEvent=null;                             
   // KoreographyEvent lastEvent=null;
    // Use this for initialization
    void Start () {
        //获取脚本组件
        playerShooting = GetComponent<CompleteProject.PlayerShooting>();
        //注册Koreographer事件与该事件要完成的函数内容
        Koreographer.Instance.RegisterForEvents(eventID, PlayerCanShoot);             
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void PlayerCanShoot(KoreographyEvent koreographyEvent)
    {   //音轨绑定时间内容，如果在事件持续时间内检测到鼠标左键按下则开火，在其他时间则不行
        if (Input.GetButtonDown("Fire1"))
        { 
        //  Debug.Log("shoot");
            playerShooting.Shoot();
        }
    }
}
