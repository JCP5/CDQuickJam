using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int Health;

    public GameObject hitSparks;

    private void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int Damage)
    {
        Health = Health - Damage;
        Instantiate(hitSparks, transform.position, transform.rotation);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        try
        {
            Spawner.instance.SubtractNumOfEnemies();
        }
        catch
        {
            Debug.LogError("No Spawner Found");
        }
    }
}
