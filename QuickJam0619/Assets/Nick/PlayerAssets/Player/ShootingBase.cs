using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBase : MonoBehaviour
{


    protected AmmoControl ammoScript;
    public int AmmoPerShot;
    public int StartingAmmoCount;
    
    public float FireRate; //Time between shots
    protected float FireRateTickingCooldown; //The ticking cooldown between shots

    // Start is called before the first frame update
    void Start()
    {
        ammoScript = gameObject.GetComponent<AmmoControl>();
        FireRateTickingCooldown = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        UniversalUpdateBehaviour();
    }

    //Use this in children instead of base.Update so we don't change the access modifier on Update() which I'm scared of doing.
    protected void UniversalUpdateBehaviour()
    {
        FireRateTickingCooldown = FireRateTickingCooldown - Time.deltaTime;
    }

    public int GetStartingAmmoCount()
    {
        return StartingAmmoCount;
    }

    public void FireShot()
    {
        ammoScript.ShotFired(AmmoPerShot);
        if (gameObject.GetComponent<GunControl>() != null)
        {
            FireRateTickingCooldown = FireRate * (1 - gameObject.GetComponent<GunControl>().FireRateImprovementPercentage);
        }
        else
        {
            FireRateTickingCooldown = FireRate;
        }
    }

    public bool CanShoot()
    {
        return FireRateTickingCooldown <= 0;
    }

}
