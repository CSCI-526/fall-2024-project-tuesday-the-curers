using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

public class Datacollection : MonoBehaviour
{
    private string formURL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSd5kCQO7n4KuZ0D2QrxPrIo3l1btaLIidIXJdqxiFAOCQ-EgQ/formResponse";
    private string entryLevelID = "entry.1729445481";
    private string time_in_tutorial = "entry.1330918088";
    public void SendLevelData(string level)
    {
        Debug.Log("SendLevelData called with level: " + level);
        StartCoroutine(PostToGoogleForm1(level));
    }
    public void SendPlayTime(float time){
        Debug.Log("SendPlayTimeData with tutorial");
        StartCoroutine(PostToGoogleForm3(time));

    }

    private IEnumerator PostToGoogleForm1(string level)
    {
        Debug.Log("Creating form data...");
        WWWForm form = new WWWForm();
        form.AddField(entryLevelID, level);

        UnityWebRequest request = UnityWebRequest.Post(formURL, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error submitting form: " + request.error);
        }
        else
        {
            Debug.Log("Form successfully submitted with level: " + level);
        }
    }
    private IEnumerator PostToGoogleForm3(float time)
    {
        Debug.Log("Creating form data...");
        WWWForm form = new WWWForm();
        form.AddField(time_in_tutorial,time.ToString());

        UnityWebRequest request = UnityWebRequest.Post(formURL, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error submitting form: " + request.error);
        }
        else
        {
            Debug.Log("Form successfully submitted with tutorial: " + time);
        }
    }
}
