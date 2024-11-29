using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class spscript : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            GameObject objectHitByRaycast = hit.transform.gameObject;

            if (objectHitByRaycast.CompareTag("spdoor"))
            {
                text.SetActive(true);
            }
        }
    }   
}
