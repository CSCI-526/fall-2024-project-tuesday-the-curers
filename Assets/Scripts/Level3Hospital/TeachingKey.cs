using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

public class TechingKey : MonoBehaviour
{
    public TMP_Text promptText; 
    public float displayDuration = 4f;  

    private void Start()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(true);
            StartCoroutine(HidePromptAfterDelay());
        }
    }

    private IEnumerator HidePromptAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);

        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }
}
