using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform player;       // 玩家对象
    public float interactionDistance = 5f; // 交互距离
    public float rotationAngle = 90f;      // 旋转角度
    public float rotationSpeed = 2f;       // 旋转速度

    private bool isRotated = false;        // 标记是否已旋转
    private Quaternion targetRotation;     // 目标旋转角度

    void Start()
    {
        // 初始化目标旋转为当前旋转角度
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // 计算玩家和门的距离
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // 检测距离并等待玩家按下 E 键
        if (distanceToPlayer <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            // 切换旋转状态
            isRotated = !isRotated;

            // 计算目标旋转角度
            targetRotation = isRotated ? Quaternion.Euler(transform.eulerAngles + new Vector3(0, rotationAngle, 0)) : Quaternion.Euler(transform.eulerAngles - new Vector3(0, rotationAngle, 0));
        }

        // 平滑旋转到目标角度
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
