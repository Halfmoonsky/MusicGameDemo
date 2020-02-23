using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 20;                  // 子弹伤害
        public float timeBetweenBullets = 0.15f;        // 射击间隔
        public float range = 100f;                      // 射程


        float timer;                                    // 记录距离上一次开火的时间
        Ray shootRay = new Ray();                       // 设置在枪口的射线，用于瞄准
        RaycastHit shootHit;                            // 射线检测中获取被击中物体的具体信息
        int shootableMask;                              // 控制可击中layer的编号
        ParticleSystem gunParticles;                    // 粒子系统变量
        LineRenderer gunLine;                           // 线性渲染器变量
        AudioSource gunAudio;                           // 音频素材变量
        Light gunLight;                                 // 光照变量
		public Light faceLight;							// ?	
        float effectsDisplayTime = 0.2f;                // 枪口火焰效果时间


        void Awake ()
        {
            // 激活一个可被击中的layer
            shootableMask = LayerMask.GetMask ("Shootable");

            // 获取组件
            gunParticles = GetComponent<ParticleSystem> ();
            gunLine = GetComponent <LineRenderer> ();
            gunAudio = GetComponent<AudioSource> ();
            gunLight = GetComponent<Light> ();
			//faceLight = GetComponentInChildren<Light> ();
        }


        void Update ()
        {
           //更新timer
            timer += Time.deltaTime;

/*#if !MOBILE_INPUT  用于检测用户输入以射击的代码，音乐游戏的射击控制放在了别的脚本中，备用
            // PC端开火控制
			if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                Shoot ();
            }
#else
            // 移动端需要瞄准并射击
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                Shoot();
            }
#endif*/
            // 没有达到最小开火间隔时间时，不应该显示枪口火焰，关闭粒子特效
            if(timer >= timeBetweenBullets * effectsDisplayTime)
            {
                DisableEffects ();
            }
        }


        public void DisableEffects ()
        {
            // 通过渲染器关闭粒子特效
            gunLine.enabled = false;
			faceLight.enabled = false;
            gunLight.enabled = false;
        }


        public void Shoot () //射击代码，每一次射击会涉及到数个变量的更新与计算
        {
            // 重置timer
            timer = 0f;

            // 枪声播放
            gunAudio.Play ();

            // 枪口火焰可显示
            gunLight.enabled = true;
			faceLight.enabled = true;

            // 枪口火焰显示，并且如果有没播放完的粒子特效就强制结束并播放新的
            gunParticles.Stop ();
            gunParticles.Play ();

            // 线性渲染器相关
            gunLine.enabled = true;
            gunLine.SetPosition (0, transform.position);

            // 射线方向及起点设置
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            // 击中后射线检测击中物体的可被击中层
            if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
            {
                // 找下怪物血量脚本。让我康康你是不是怪
                EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

                // 如果有，就扣血（子弹哥不要啊）
                if(enemyHealth != null)
                {
                    
                    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
                }

                // 把射线的另一个端点设置在被击中物体上
                gunLine.SetPosition (1, shootHit.point);
            }
            // 我们的攻击没能穿透敌人的装甲
            else
            {
                // 把射线的另一个端点设置在最大射程点上
                gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}