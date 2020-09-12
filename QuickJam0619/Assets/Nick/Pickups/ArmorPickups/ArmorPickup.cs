using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPickup : Pickup
{
    public float ArmorHealthIncrease = 0;
    public float FlatReductionIncrease = 0;
    public float PercentageReductionIncrease = 0;

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

            if (DestroyPickupsOnPickup)
            {
                DestroyOtherPickups();
            }

            collision.gameObject.GetComponent<PlayerHealth>().AddArmorHealth(ArmorHealthIncrease);
            collision.gameObject.GetComponent<PlayerHealth>().AddFlatArmorReduction(FlatReductionIncrease);
            collision.gameObject.GetComponent<PlayerHealth>().AddPercentageArmorReduction(PercentageReductionIncrease);
        }
    }
}
