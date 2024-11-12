using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTimer : MonoBehaviour
{
    private float startTime;
    private float endTime;
    public float playTime;
    // Start is called before the first frame update
    void Start()
    {
        StartTimer();
    }
    void StartTimer()
    {
        startTime = Time.time;
        Debug.Log("Timer started at: " + startTime + " seconds");
    }
    public void StopTimer()
    {
        // Record the end time and calculate the play time
        endTime = Time.time;
        playTime = endTime - startTime;
        Debug.Log("Timer stopped at: " + endTime + " seconds");
        Debug.Log("Total play time in scene: " + playTime + " seconds");

        // You can save or send this playTime to your Datacollection system if needed
        // datacollection.SendPlayTime(playTime);  // Example function call
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
