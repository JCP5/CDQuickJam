using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public delegate void deathDelegate();
    public event deathDelegate deathEvent;

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

        if (deathEvent != null)
        {
            deathEvent();
        }
    }
}
