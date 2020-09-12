using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : Pickup
{
    public float FireRateImprovementPercentage = 0;

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
        if (collision.gameObject.GetComponent<GunControl>() != null)
        {
            collision.gameObject.GetComponent<GunControl>().ImproveFireRate(FireRateImprovementPercentage);
        }
    }
}
