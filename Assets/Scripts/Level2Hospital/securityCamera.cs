using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityCamera : MonoBehaviour
{
    public Vector3 startRotation = new Vector3(28.925f, -227.8f, -10.69f);  // 第一个照片的旋转
    public Vector3 endRotation = new Vector3(26.679f, -174.3f, 15.74f);     // 第二个照片的旋转
    public float rotationSpeed = 1.0f;                                      // 控制旋转速度

    private Quaternion startQuaternion;
    private Quaternion endQuaternion;
    private bool rotatingToEnd = true;  // 是否从第一个旋转到第二个

    void Start()
    {
        // 将 Euler 角转换为 Quaternion
        startQuaternion = Quaternion.Euler(startRotation);
        endQuaternion = Quaternion.Euler(endRotation);

        // 设置摄像机的初始旋转
        transform.rotation = startQuaternion;
    }

    void Update()
    {
        if (rotatingToEnd)
        {
            // 从当前旋转插值到目标旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, endQuaternion, rotationSpeed * Time.deltaTime);

            // 检查是否接近目标旋转
            if (Quaternion.Angle(transform.rotation, endQuaternion) < 0.1f)
            {
                rotatingToEnd = false;
            }
        }
        else
        {
            // 从当前旋转插值到起始旋转
            transform.rotation = Quaternion.Slerp(transform.rotation, startQuaternion, rotationSpeed * Time.deltaTime);

            // 检查是否接近起始旋转
            if (Quaternion.Angle(transform.rotation, startQuaternion) < 0.1f)
            {
                rotatingToEnd = true;
            }
        }
    }
}
