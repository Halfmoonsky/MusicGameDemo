using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // 玩家得分


        Text text;                      // text组件


        void Awake ()
        {
            // 实例化
            text = GetComponent <Text> ();

            // 重置
            score = 0;
        }


        void Update ()
        {
            // 得分实时更新
            text.text = "得分: " + score;
        }
    }
}