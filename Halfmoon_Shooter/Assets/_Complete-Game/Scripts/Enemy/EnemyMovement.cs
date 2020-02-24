using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // 玩家的位置
        PlayerHealth playerHealth;      // 玩家血量
        EnemyHealth enemyHealth;        // 怪物血量
        UnityEngine.AI.NavMeshAgent nav;               // NavmeshAgent组件，用于AI自动寻路


        void Awake ()
        {
            // 各种实例化
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        }


        void Update ()
        {
            // 玩家怪物都有血
            if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                //把玩家位置作为终点寻路
                nav.SetDestination (player.position);
            }
            else
            {
                // 任有一个条件不满足便停止使用nav
                nav.enabled = false;
            }
        }
    }
}