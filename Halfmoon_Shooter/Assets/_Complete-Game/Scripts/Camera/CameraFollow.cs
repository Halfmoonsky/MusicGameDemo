using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            // 摄像机跟随的位置
        public float smoothing = 5f;        // 移动速度


        Vector3 offset;                     // 摄像机与人物的距离


        void Start ()
        {
            // 计算预设距离
            offset = transform.position - target.position;
        }


        void FixedUpdate ()
        {
            // 根据offset实时计算摄像机位置
            Vector3 targetCamPos = target.position + offset;

            // 利用插值函数平滑的实现摄像机移动
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}