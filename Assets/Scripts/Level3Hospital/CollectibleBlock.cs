using UnityEngine;

public class CollectibleBlock : MonoBehaviour
{
    public int prefabIndex; // 方块对应的 prefab 索引

    private void Start()
    {
        // 设置方块名称与其对应的字母相同
        switch (prefabIndex)
        {
            case 1:
                gameObject.name = "G";
                break;
            case 2:
                gameObject.name = "A";
                break;
            case 3:
                gameObject.name = "T";
                break;
            case 4:
                gameObject.name = "E";
                break;
            default:
                break;
        }
    }
}
