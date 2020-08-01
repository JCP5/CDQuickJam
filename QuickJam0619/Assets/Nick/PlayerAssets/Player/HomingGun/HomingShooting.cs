using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShooting : ShootingBase
{
    public GameObject Shot;

    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GetComponent<Transform>();

        ammoScript = gameObject.GetComponent<AmmoControl>();

    }

    // Update is called once per frame
    void Update()
    {
        UniversalUpdateBehaviour();

        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            Instantiate(Shot, playerPos.position, Quaternion.identity);
            FireShot();
        }
    }
}
