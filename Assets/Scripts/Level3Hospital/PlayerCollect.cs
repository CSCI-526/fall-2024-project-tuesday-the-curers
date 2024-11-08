
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] blockPrefabs; // 用于放置的方块 prefabs 数组
    private List<GameObject> collectedBlocks = new List<GameObject>(); // 存储已收集的方块的 prefab

    private void Update()
    {
        // 检测是否按下 E 键进行收集
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 射线检测是否有方块在玩家面前
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f)) // 2f 是检测距离
            {
                if (hit.collider.CompareTag("CollectibleBlock")) // 确保碰撞体是可收集的方块
                {
                    CollectBlock(hit.collider.gameObject, hit.collider.GetComponent<CollectibleBlock>().prefabIndex); // 传递 prefab 索引
                }
            }
        }

        // 检测是否按下 F 键进行放置
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceBlock(); // 放置方块
        }
    }

    private void CollectBlock(GameObject block, int prefabIndex)
    {
        // 将收集的方块的 prefab 索引添加到列表中
        collectedBlocks.Add(blockPrefabs[prefabIndex]); // 将对应的 prefab 添加到列表中

        // 禁用收集的方块，使其暂时不可见
        block.SetActive(false); // 使方块不可见
    }

    private void PlaceBlock()
    {
        if (collectedBlocks.Count > 0)
        {
            // 从已收集的方块中取出一个并放置
            GameObject blockToPlace = collectedBlocks[collectedBlocks.Count - 1]; // 取出最后一个方块的 prefab
            collectedBlocks.RemoveAt(collectedBlocks.Count - 1); // 从列表中移除已放置的方块

            // 在玩家面前放置方块
            Vector3 positionToPlace = transform.position + transform.forward; // 放置位置可以根据需要进行调整
            GameObject placedBlock = Instantiate(blockToPlace, positionToPlace, Quaternion.identity); // 实例化方块

            // 确保新放置的方块是激活的
            placedBlock.SetActive(true);
        }
    }
}*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to work with TextMeshPro

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] blockPrefabs; // 用于放置的方块 prefabs 数组
    private List<GameObject> collectedBlocks = new List<GameObject>(); // 存储已收集的方块 prefab

    private void Update()
    {
        // 检测是否按下 E 键进行收集
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 射线检测是否有方块在玩家面前
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f)) // 2f 是检测距离
            {
                if (hit.collider.CompareTag("CollectibleBlock")) // 确保碰撞体是可收集的方块
                {
                    CollectBlock(hit.collider.gameObject);//加了 // 收集方块
                }
            }
        }

        // 检测是否按下 F 键进行放置
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceBlock(); // 放置方块
        }
    }

    private void CollectBlock(GameObject block)
    {
        // 将收集的方块添加到列表中
        collectedBlocks.Add(block); // 将收集的方块添加到列表中

        // 禁用收集的方块，使其暂时不可见
        block.SetActive(false); // 使方块不可见
    }

    private void PlaceBlock()
    {
        if (collectedBlocks.Count > 0)
        {
            // 从已收集方块中取出最后一个并放置
            GameObject blockToPlace = collectedBlocks[0]; // 取出第一个收集的方块
            collectedBlocks.RemoveAt(0); // 从列表中移除已放置的方块

            // 在玩家面前放置方块
            Vector3 positionToPlace = transform.position + transform.forward; // 放置位置可以根据需要进行调整
            GameObject placedBlock = Instantiate(blockToPlace, positionToPlace, Quaternion.identity); // 实例化方块

            // 确保新放置的方块是激活的
            placedBlock.SetActive(true);

            // 设置放置方块的文本
            TextMeshPro textMesh = placedBlock.GetComponentInChildren<TextMeshPro>(); // 获取 TextMeshPro 组件
            if (textMesh != null)
            {
                textMesh.text = blockToPlace.name; // 设置文本为方块的名称
            }
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] blockPrefabs; // 用于放置的方块 prefabs 数组
    private List<GameObject> collectedBlocks = new List<GameObject>(); // 存储已收集的方块 prefab

    private void Update()
    {
        // 检测是否按下 E 键进行收集
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 射线检测是否有方块在玩家面前
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f)) // 2f 是检测距离
            {
                if (hit.collider.CompareTag("CollectibleBlock")) // 确保碰撞体是可收集的方块
                {
                    CollectBlock(hit.collider.gameObject); // 收集方块
                }
            }
        }

        // 检测是否按下 F 键进行放置
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceBlock(); // 放置方块
        }
    }

    private void CollectBlock(GameObject block)
    {
        // 将收集的方块添加到列表中
        collectedBlocks.Add(block); // 将收集的方块添加到列表中

        // 禁用收集的方块，使其暂时不可见
        block.SetActive(false); // 使方块不可见

        // 通知 ExitDoormangager 收集到的方块
        ExitDoormangager exitManager = FindObjectOfType<ExitDoormangager>();
        if (exitManager != null)
        {
            exitManager.OnCubeCollected(block.name); // 传递方块名称
        }
    }

    private void PlaceBlock()
    {
        if (collectedBlocks.Count > 0)
        {
            // 从已收集方块中取出最后一个并放置
            GameObject blockToPlace = collectedBlocks[0]; // 取出第一个收集的方块
            collectedBlocks.RemoveAt(0); // 从列表中移除已放置的方块

            // 在玩家面前放置方块
            Vector3 positionToPlace = transform.position + transform.forward; // 放置位置可以根据需要进行调整
            GameObject placedBlock = Instantiate(blockToPlace, positionToPlace, Quaternion.identity); // 实例化方块

            // 确保新放置的方块是激活的
            placedBlock.SetActive(true);
        }
    }
}