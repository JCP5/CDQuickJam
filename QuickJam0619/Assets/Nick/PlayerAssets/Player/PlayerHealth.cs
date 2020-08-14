using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public float health;
    public float maxHealth;

    void Awake()
    {
        instance = this;
    }
    public void TakeDamage(int Damage)
    {
        health = health - Damage;
        HealthBar.instance.SetHealthBarScale(health / maxHealth);
        Debug.Log("Health % " + health / maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<Spawner>().enabled = false;
        Debug.Log("Rest In Pepperoni");
    }
}
