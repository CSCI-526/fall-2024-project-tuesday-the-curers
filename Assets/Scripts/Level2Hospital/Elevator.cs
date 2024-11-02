using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float moveDistance = 8f;    // 移动的距离
    public float speed = 2f;           // 移动速度
    public float waitTime = 4f;        // 每次到达位置后的等待时间

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingUp = true;      // 是否向上移动
    private float waitTimer = 0f;

    void Start()
    {
        // 使用当前物体位置为起始位置
        startPosition = transform.position;

        // 根据移动距离计算结束位置
        endPosition = new Vector3(startPosition.x, startPosition.y + moveDistance, startPosition.z);

        // 初始化位置
        transform.position = startPosition;
    }

    void Update()
    {
        // 如果处于等待状态，减少等待时间
        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            return; // 退出 Update，等待时间倒计时完成后再继续移动
        }

        // 在两个位置之间来回移动
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                movingUp = false;
                waitTimer = waitTime; // 设置等待时间
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                movingUp = true;
                waitTimer = waitTime; // 设置等待时间
            }
        }
    }
}
