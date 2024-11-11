using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playerState : MonoBehaviour
{
    // Health control
    public float health;
    public float Maxhealth;
    public Slider slider;

    public GameObject lossUI;
    
    public float dealy = 1.5f;
    public float delay2 = 1f;
    private float timmer = 0;
    private float timmer2 = 0;

    void Start()
    {

        // Health ini
        health = Maxhealth;
        slider.value = calHealth();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private float calHealth()
    {
        return health / Maxhealth;
    }

    private void HealthCheck()
    {


        if (health <= 0)
        {
            lossUI.GetComponent<rangeUIControl>().showLoseUI();
        }
        if (health > Maxhealth)
        {
            health = Maxhealth;
        }
        slider.value = calHealth();
    }

    void Update()
    {
        HealthCheck();
        timmer2 += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(timmer2 > delay2)
            {
                TakeDamage(10);
                timmer2 = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (timmer > dealy)
            {
                TakeDamage(10);
                timmer = 0;
            }
            timmer += Time.deltaTime;
        }
    }
}
