using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float HealAmount = 0;
    public float MaxHealthIncrease = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void PickupBehaviour(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().AddMaxHealth(MaxHealthIncrease);
            collision.gameObject.GetComponent<PlayerHealth>().HealCurrentHealth(HealAmount);
        }

    }
}
