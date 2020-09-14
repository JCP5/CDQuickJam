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
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void PickupBehaviour(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().AddArmorHealth(ArmorHealthIncrease);
            collision.gameObject.GetComponent<PlayerHealth>().AddFlatArmorReduction(FlatReductionIncrease);
            collision.gameObject.GetComponent<PlayerHealth>().AddPercentageArmorReduction(PercentageReductionIncrease);
            Camera.main.GetComponent<AudioSource>().Stop();
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
