using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class INfection_Timmer : MonoBehaviour
{
    public int timmernum = 30;
    public float timmer;

    public TextMeshProUGUI timmerUI;
    // Start is called before the first frame update
    void Start()
    {
        timmer = timmernum;
    }

    // Update is called once per frame
    void Update()
    {
        timmerUI.text = "Infection increase in " + (int)timmer + " sec";
        timmer -= Time.deltaTime;
        if(timmer < 0)
        {
            timmer = timmernum;
        }
    }
}
