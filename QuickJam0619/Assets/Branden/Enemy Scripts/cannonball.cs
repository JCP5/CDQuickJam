using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball : MonoBehaviour
{
    public GameObject cannonHitParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("??");
        if(collision.gameObject.CompareTag("Player") || (collision.gameObject.CompareTag("Walls")))
        {
            Instantiate(cannonHitParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
