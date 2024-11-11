using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_nav : MonoBehaviour
{
    public GameObject nvob;
    public GameObject Target_indicator;
    void Start()
    {
        // Find the "DynamicTarget" object in the hierarchy
        //Target_indicator = transform.Find("DynamicTarget").gameObject;
    }
}
