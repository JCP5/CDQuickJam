using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBase : MonoBehaviour
{


    protected AmmoControl ammoScript;
    public int AmmoPerShot;
    public int StartingAmmoCount;

    // Start is called before the first frame update
    void Start()
    {
        ammoScript = gameObject.GetComponent<AmmoControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetStartingAmmoCount()
    {
        return StartingAmmoCount;
    }

    public void FireShot()
    {
        ammoScript.ShotFired(AmmoPerShot);
    }
}
