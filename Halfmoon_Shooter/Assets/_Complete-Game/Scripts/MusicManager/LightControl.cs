using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class LightControl : MonoBehaviour {
    public string eventID;                                                   //标题界面控制灯光随音乐开关的脚本
    private Light spotLight;                                                //两个变量分别是音轨事件名和灯光变量
	// Use this for initialization
	void Start () {
        //各种实例化
        spotLight = GetComponent<Light>();                                   
        //注册音轨事件，绑定完成的功能
        Koreographer.Instance.RegisterForEvents(eventID,ShingingLight);      
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void ShingingLight(KoreographyEvent koreographyEvent)
    {    //每一次音轨事件自动改变灯的开关
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
