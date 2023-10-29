using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health_System : MonoBehaviour
{
    public float maxHealth = 100f;
    public GameObject healthBar;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        healthBar.GetComponent<Slider>().value = maxHealth;
    }

    private void Update()
    {
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0);
    }

    public void DecreaseHealth(float damage)
    {
        currentHealth -= damage;
        healthBar.GetComponent<Slider>().value = currentHealth;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void IncreaseHealth(float heal)
    {
        currentHealth += heal;
        if (currentHealth >= 100f)
            currentHealth = 100f;
        healthBar.GetComponent<Slider>().value = currentHealth;
    }
}
