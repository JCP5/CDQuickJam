using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int Health;

    public GameObject hitSparks;
    public GameObject deathParticle;

    private void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int Damage)
    {
        Health = Health - Damage;

        if (Health > 0)
        {
            Instantiate(hitSparks, transform.position, transform.rotation);
        }
        else if (Health <= 0)
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
            Destroy(this.gameObject);
        }

        if (Health <= 0)
        {
            Instantiate(deathParticle, this.transform.position, Quaternion.identity);
        }
    }
}
