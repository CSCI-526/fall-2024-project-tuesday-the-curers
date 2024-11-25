using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieState : MonoBehaviour
{
    // Health control
    public float health;
    public float Maxhealth;
    public GameObject healthbar;
    public Slider slider;

    public bool is_night = false;
    public bool sp = false;
    public bool ndmg = false;
    public bool boss = false;

    // Color Controll
    public float timmer = 30f;
    private Renderer objectRenderer;
    public int zombie_state = 0;
    private Color[] colors = {new Color(1f, 0.5f, 0f), Color.red ,new Color(0.5f, 0f, 0.5f) };

    // Movement Control
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Color ini
        objectRenderer = GetComponent<Renderer>();
        if (boss)
        {
            objectRenderer.material.color = new Color(0f, 0.5f, 0f, 1f);
        }
        else
        {
            objectRenderer.material.color = colors[zombie_state];
        }
        

        // Health ini
        if(sp == false)
        {
            health = Maxhealth;
            
        }
        slider.value = calHealth();


        // State ini
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void colordeeper()
    {
        if (objectRenderer != null && zombie_state < 2)
        {
            zombie_state++;
            objectRenderer.material.color = colors[zombie_state];
            timmer = 10f;
        }
    }

    public void colorlighter()
    {
        if (objectRenderer != null && zombie_state > 0)
        {
            zombie_state--;
            objectRenderer.material.color = colors[zombie_state];
            timmer = 10f;
            health = Maxhealth;
        }
        else if(zombie_state == 0)
        {
            curedCount.Instance.count++;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        if (boss)
        {
            return;
        }
        if (ndmg && health <= 50)
        {
            return;

        }
        health -= damage;
    }

    private float calHealth()
    {
        return health / Maxhealth;
    }

    private void HealthCheck()
    {
        timmer -= Time.deltaTime;
        if (timmer <= 0 && !boss)
        {
            colordeeper();
        }

  
        if (health <= 0)
        {
            curedCount.Instance.killed++;
            Destroy(gameObject);
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
        if (DayNightCycle.Instance != null)
        {
            is_night = DayNightCycle.Instance.IsNight();
        }
    }
}
