using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AmmoControl : MonoBehaviour
{

    int ammoRemaining;

    GunControl switchGunScript;

    ShootingBase activeGunScript;

    // Start is called before the first frame update
    void Start()
    {
        switchGunScript = gameObject.GetComponent<GunControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShotFired(int ammoReduction)
    {
        ammoRemaining = ammoRemaining - ammoReduction;
        AmmoUI.instance.SetAmmo(ammoRemaining);

        if (ammoRemaining <= 0)
        {
            switchGunScript.RerollGun();
        }
    }

    public void SetAmmoRemaining(int newAmmoAmount)
    {
        ammoRemaining = newAmmoAmount;
    }
}
