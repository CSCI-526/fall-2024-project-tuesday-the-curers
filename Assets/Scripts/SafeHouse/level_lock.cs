using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_lock : MonoBehaviour
{
    public GameObject friUI;
    public GameObject cpyUI;
    public GameObject hisUI;
    public GameObject fribut;
    public GameObject cpybut;
    public GameObject hisbiut;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerResource.Instance != null)
        {
            if (PlayerResource.Instance.forest)
            {
                friUI.SetActive(true);
                fribut.SetActive(true);
            }
            else
            {
                friUI.SetActive(false);
                fribut.SetActive(false);
            }

            if (PlayerResource.Instance.compant)
            {
                cpybut.SetActive(true);
                cpyUI.SetActive(true);
            }
            else
            {
                cpybut.SetActive(false);
                cpyUI.SetActive(false);
            }
            if (PlayerResource.Instance.hospital)
            {
                hisbiut.SetActive(true);
                hisUI.SetActive(true);
            }
            else
            {
                hisbiut.SetActive(false);
                hisUI.SetActive(false);
            }
        }
    }
}
