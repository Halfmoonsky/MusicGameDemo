using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyAttack : MonoBehaviour
    {
        public float timeBetweenAttacks = 0.5f;     // 攻击速度，一秒数刀
        public int attackDamage = 10;               // 攻击伤害


        Animator anim;                              // 各种组件
        GameObject player;                          
        PlayerHealth playerHealth;                  // 与玩家生命值关联的脚本
        EnemyHealth enemyHealth;                    // 与怪物生命值关联的脚本
        bool playerInRange;                         // 玩家是否处于攻击范围
        float timer;                                // 为下次攻击计时


        void Awake ()
        {
            // 各种实例化
            player = GameObject.FindGameObjectWithTag ("Player");
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent <Animator> ();
        }


        void OnTriggerEnter (Collider other)
        {
            // 我摸到了，我摸到了！狗头人.jpg 指触发器是玩家的
            if(other.gameObject == player)
            {
                // 我看到你了（士兵76）
                playerInRange = true;
            }
        }


        void OnTriggerExit (Collider other)
        {
            // 如果玩家触发器走了
            if(other.gameObject == player)
            {
                // 就是超出范围
                playerInRange = false;
            }
        }


        void Update ()
        {
            // 更新计时器
            timer += Time.deltaTime;

            // 该打趴你了，指可以攻击了
            if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
            {
                Attack ();
            }

            // 哎哟，你没血了
            if(playerHealth.currentHealth <= 0)
            {
                //animator，放死亡动画
                anim.SetTrigger ("PlayerDead");
            }
        }


        void Attack ()
        {
            // 重置计时器
            timer = 0f;

            // 玩家还有血，那就打
            if(playerHealth.currentHealth > 0)
            {
                playerHealth.TakeDamage (attackDamage);
            }
        }
    }
}