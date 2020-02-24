using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // 玩家血量
        public GameObject enemy;                // 要刷新的怪
        public float spawnTime = 3f;            // 怪物刷新时间
        public Transform[] spawnPoints;         // 怪物刷新点的数组


        void Start ()
        {
            // InvokeRepeating功能为重复执行某函数，三个参数分别为要重复执行的函数名，开始时间与间隔
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // 玩家死亡
            if(playerHealth.currentHealth <= 0f)
            {
                return;
            }

            // 随机选择刷新点的序号
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // 在选择的刷新点刷新新怪
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}