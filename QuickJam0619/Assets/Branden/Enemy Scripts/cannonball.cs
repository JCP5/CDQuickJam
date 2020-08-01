using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball : MonoBehaviour
{
    public GameObject cannonHitParticles;

    public int damageDealt = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || (collision.gameObject.CompareTag("Walls")) || (collision.gameObject.CompareTag("Obstacles")))
        {
            try
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageDealt);
                Instantiate(cannonHitParticles, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            catch
            {
                Instantiate(cannonHitParticles, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
