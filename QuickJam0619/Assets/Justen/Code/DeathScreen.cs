using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.deathEvent += DeathScreenOn;
        this.gameObject.SetActive(false);
    }

    public void DeathScreenOn()
    {
        this.gameObject.SetActive(true);
    }
}
