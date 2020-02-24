using UnityEngine;
using System.Collections;

public class RandomParticlePoint : MonoBehaviour 
{
    [Range(0f, 1f)]
    public float normalizedTime;


    void OnValidate()
    {
        GetComponent<ParticleSystem>().Simulate (normalizedTime, true, true);//可以使粒子特效不受游戏内时间影响，永远不要停下来啊！
    }
}
