using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory_after_delay : MonoBehaviour
{
    public int time = 3;
    // Update is called once per frame
    void Update()
    {
        DestroyAfterDelay();
    }

    public void DestroyAfterDelay()
    {
        Invoke("DestroyGameObject", time);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
