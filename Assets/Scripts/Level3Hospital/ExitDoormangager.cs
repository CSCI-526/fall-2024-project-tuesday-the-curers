using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoormangager : MonoBehaviour
{
    public GameObject exitDoor; // 退出门的引用
    private HashSet<string> collectedCubeNames = new HashSet<string>(); // 用于存储已收集的方块名称

    private void Start()
    {
        // 开始时隐藏退出门
        if (exitDoor != null)
        {
            exitDoor.SetActive(false);
        }
    }

    private void Update()
    {
        // 检查是否已收集所有必要的方块
        if (AreAllCubesCollected())
        {
            if (exitDoor != null)
            {
                exitDoor.SetActive(true);
                Debug.Log("Exit door is now active.");
            }
        }
    }

    // 检查是否已收集所有方块
    private bool AreAllCubesCollected()
    {
        // 检查集合中是否包含所有必要的方块
        return collectedCubeNames.Contains("G") &&
               collectedCubeNames.Contains("A") &&
               collectedCubeNames.Contains("T") &&
               collectedCubeNames.Contains("E");
    }

    // 在方块被收集时调用此方法
    public void OnCubeCollected(string cubeName)
    {
        collectedCubeNames.Add(cubeName);
    }
}
