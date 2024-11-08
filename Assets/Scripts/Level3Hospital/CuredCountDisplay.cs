using System.Collections;
using UnityEngine;
using TMPro; // 引入 TextMeshPro 命名空间

public class CuredCountDisplay : MonoBehaviour
{
    public GameObject promptTextPrefab; // 用于显示提示的文本 prefab
    private GameObject currentPrompt; // 当前显示的提示对象

    private void Update()
    {
        // 检查 curedCount 的实例是否存在，并且计数达到2
        if (curedCount.Instance != null && curedCount.Instance.count >= 2)
        {
            if (currentPrompt == null) // 确保提示文本没有显示
            {
                ShowPrompt(); // 显示提示
            }
        }
    }

    private void ShowPrompt()
    {
        // 创建提示文本对象
        currentPrompt = Instantiate(promptTextPrefab, Camera.main.transform.position + Camera.main.transform.forward * 2, Quaternion.identity);
        currentPrompt.transform.LookAt(Camera.main.transform); // 确保提示面向玩家

        // 设置文本内容
        TextMeshPro textMesh = currentPrompt.GetComponentInChildren<TextMeshPro>();
        if (textMesh != null)
        {
            textMesh.text = "Try to find GATE"; // 设置提示文本
        }

        // 使提示在一段时间后消失
        Destroy(currentPrompt, 5f); // 5秒后销毁提示
    }
}
