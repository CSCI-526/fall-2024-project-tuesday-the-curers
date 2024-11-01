using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOfftime : MonoBehaviour
{
    public Light lightSource; // 灯光对象
    public float toggleInterval = 5f; // 切换间隔时间（秒）

    private bool isLightOn = false; // 记录灯的状态

    void Start()
    {
        // 确保灯光初始状态为关闭
        if (lightSource != null)
        {
            lightSource.enabled = isLightOn;
        }

        // 每隔 toggleInterval 秒切换灯的状态
        InvokeRepeating("ToggleLight", toggleInterval, toggleInterval);
    }

    void ToggleLight()
    {
        // 切换灯的状态
        if (lightSource != null)
        {
            isLightOn = !isLightOn;
            lightSource.enabled = isLightOn;
        }
    }
}
