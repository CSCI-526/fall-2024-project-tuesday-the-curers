using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spscript : MonoBehaviour
{
    public GameObject text;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            GameObject objectHitByRaycast = hit.transform.gameObject;

            if (objectHitByRaycast.CompareTag("spdoor") && text != null)
            {
                text.SetActive(true);
            }
        }
    }   
}
