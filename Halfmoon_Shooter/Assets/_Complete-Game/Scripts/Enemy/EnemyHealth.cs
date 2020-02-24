using UnityEngine;

namespace CompleteProject
{
    public class EnemyHealth : MonoBehaviour
    {
        public int startingHealth = 10;             // 究极脆皮怪，改成音游后打的挺慢的，就把怪物的血调低了
        public int currentHealth;                   // 实时血量.
        public float sinkSpeed = 2.5f;              // 这个游戏，怪物死了竟然会掉下地板的，这是掉下去的速度
        public int scoreValue = 10;                 // 击杀得分
        public AudioClip deathClip;                 // 怪物死亡音效


        Animator anim;                              // 各种组件
        AudioSource enemyAudio;                     
        ParticleSystem hitParticles;                
        CapsuleCollider capsuleCollider;            
        bool isDead;                                // 啪，怪是不是死了
        bool isSinking;                             // 怪是否在往下掉


        void Awake ()
        {
            // 各种实例化
            anim = GetComponent <Animator> ();
            enemyAudio = GetComponent <AudioSource> ();
            hitParticles = GetComponentInChildren <ParticleSystem> ();
            capsuleCollider = GetComponent <CapsuleCollider> ();

            // 设置实时血量
            currentHealth = startingHealth;
        }


        void Update ()
        {
            // 如果怪死了该往下掉了
            if(isSinking)
            {
                // 让怪慢慢下沉
                transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            }
        }


        public void TakeDamage (int amount, Vector3 hitPoint)
        {
            // 怪被杀
            if(isDead)
                // 就会死
                return;

            // 伤害音效
            enemyAudio.Play ();

            // 扣血
            currentHealth -= amount;
            
            // 在打到的位置播放粒子特效
            hitParticles.transform.position = hitPoint;

            // 喷！
            hitParticles.Play();

            // 怪刚被杀
            if(currentHealth <= 0)
            {
                // 也会死
                Death ();
            }
        }


        void Death ()
        {
            // 死了啦
            isDead = true;

            // 把碰撞器变为触发器，这样子弹就能穿过了，很细节
            capsuleCollider.isTrigger = true;

            // 放死亡动画
            anim.SetTrigger ("Dead");

            // 播放死亡音效
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();
        }


        public void StartSinking ()
        {
            // 结束寻路
            GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;

            // isKinematic：动力学模拟，当值为true的时候表示关闭，我们使用了translate来让怪物下沉，所以不需要模拟
            GetComponent<Rigidbody> ().isKinematic = true;

            // 该不该沉
            isSinking = true;

            // 加分
            ScoreManager.score += scoreValue;

            // 2s后销毁物体
            Destroy (gameObject, 2f);
        }
    }
}