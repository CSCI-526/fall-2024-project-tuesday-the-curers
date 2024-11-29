using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hospital_dial : MonoBehaviour
{
    public TextMeshProUGUI text;

    private List<string> begindialog = new List<string> {
        "Use mouse right to open flash light",
        "Zombies only attracted by flash light!!"
    };

    private int index = 0;
    private float timer = 0f;
    public float interval = 8f; 

    void Start()
    {
        text.text = begindialog[index]; 
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f; 
            index++;   

            if (index < begindialog.Count)
            {
                text.text = begindialog[index];
            }
            else
            {
                Destroy(text.gameObject); 
            }
        }
    }
}
