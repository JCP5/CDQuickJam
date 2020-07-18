using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health;

    public void TakeDamage(int Damage)
    {
        Health = Health - Damage;

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
