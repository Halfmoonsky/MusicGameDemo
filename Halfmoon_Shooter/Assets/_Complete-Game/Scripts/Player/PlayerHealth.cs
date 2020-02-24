using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject
{
    public class PlayerHealth : MonoBehaviour
    {
        public int startingHealth = 100;                            // 玩家初始血量
        public int currentHealth;                                   // 玩家现存血量
        public Slider healthSlider;                                 // 血条UI
        public Image damageImage;                                   // 在被击中时屏幕闪的一下红
        public AudioClip deathClip;                                 // 玩家死亡音效
        public float flashSpeed = 5f;                               // 闪的那一下红的消失速度
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // 设定闪的那下的颜色，这里是红


        Animator anim;                                              // 各种组件
        AudioSource playerAudio;                                    
        PlayerMovement playerMovement;                              
        PlayerShooting playerShooting;                              
        bool isDead;                                                // 玩家是否死亡
        bool damaged;                                               // 玩家是否被击中


        void Awake ()
        {
            // 各种实例化
            anim = GetComponent <Animator> ();
            playerAudio = GetComponent <AudioSource> ();
            playerMovement = GetComponent <PlayerMovement> ();
            playerShooting = GetComponentInChildren <PlayerShooting> ();

            // 给现存血量赋值
            currentHealth = startingHealth;
        }


        void Update ()
        {
            //我被击中了！
            if(damaged)
            {
                //两眼发红
                damageImage.color = flashColour;
            }
            else
            {
                //利用插值函数逐渐使伤害图片淡去
                damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // 重置是否被击中的flag
            damaged = false;
        }


        public void TakeDamage (int amount)
        {
            // 我被敌军击中
            damaged = true;

            // 现在的血量减少了！.jpg
            currentHealth -= amount;

            // 血条也跟着减少了
            healthSlider.value = currentHealth;

            // 播放受伤音效（娇喘
            playerAudio.Play ();

            // 人被杀
            if(currentHealth <= 0 && !isDead)
            {
                // 就会死
                Death ();
            }
        }


        void Death ()
        {
            // 人的生命只有一次，这个变量也只会在玩家死亡时变为true一次
            isDead = true;

            // 撤销枪口子弹的各种特效（感觉好安静啊，地图上也没有怪
            playerShooting.DisableEffects ();

            // 状态机播放死亡动画（组件们都在工作，脚本也没有bug，我也要加把劲才行
            anim.SetTrigger ("Die");

            // 播放死亡音效（希 望 之 花
            playerAudio.clip = deathClip;
            playerAudio.Play ();

            // 关闭角色移动和射击（什么嘛，我射的还蛮准的；所以，不要停下来啊！
            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }


        public void RestartLevel ()
        {
            //切换场景（请收看下一集
            SceneManager.LoadScene (1);
        }
    }
}