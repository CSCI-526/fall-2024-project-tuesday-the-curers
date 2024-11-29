using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;          
    private bool isFlashlightOn = false;
    public float maxDistance = 40f;     

    void Start()
    {
        flashlight.enabled = isFlashlightOn;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            isFlashlightOn = !isFlashlightOn;
            flashlight.enabled = isFlashlightOn;
        }
    }
}
