using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCount : MonoBehaviour
{
    public static PickupCount Instance { get; set; }

    public int level_mission;

    public int count = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}