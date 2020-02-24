using UnityEngine;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       //玩家血量


        Animator anim;                   //游戏动画状态机       


        void Awake ()
        {
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            // 玩家死亡
            if(playerHealth.currentHealth <= 0)
            {
                //播放游戏结束动画
                anim.SetTrigger ("GameOver");
            }
        }
    }
}