using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShooting : ShootingBase
{
    public GameObject shot;
    public float deadZoneSize;
    public int bullets;
    public float spreadBreadth;

    private Vector2 target;
    private Vector2 playerPos;

    private Vector2 projectileVelocity;
    private Vector2 projectileDirection;

    private Vector2 spawnLocation;

    private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        ammoScript = gameObject.GetComponent<AmmoControl>();
    }

    // Update is called once per frame
    void Update()
    {

        UniversalUpdateBehaviour();

        if (Input.GetMouseButtonDown(0) && CanShoot())
        {
            //Where did they click?
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            //Current player location so we know where the projectile is coming from
            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

            //Calculate the direction the projectile should be going as a normalized vector
            projectileVelocity = target - playerPos;
            projectileDirection = projectileVelocity.normalized;

            //Rotate the projectile to face the direction it is travelling
            float angle = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Calculate where the projectile should spawn to include the deadzone
            spawnLocation = playerPos + (projectileDirection * deadZoneSize);

            //Spawn our bullets two at a time to create a mirror spread effect
            //We spawn the bullet
            for (int i = bullets / 2; i > 0; i--)
            {
                //First bullet, positive spread angle
                bullet = Instantiate(shot, spawnLocation, Quaternion.identity);
                bullet.GetComponent<ShotgunProjectileMovement>().adjustmentAngle = spreadBreadth * i;

                //Second bullet, mirror of first bullet, aka negative spread angle
                bullet = Instantiate(shot, spawnLocation, Quaternion.identity);
                bullet.GetComponent<ShotgunProjectileMovement>().adjustmentAngle = spreadBreadth * -i;
            }

            //Odd number of bullets, which means their spread is mirrored and also has a no deviation middle bullet
            if (bullets % 2 != 0)
            {
                bullet = Instantiate(shot, spawnLocation, Quaternion.identity);
                bullet.GetComponent<ShotgunProjectileMovement>().adjustmentAngle = 0;
            }

            FireShot();

        }
    }
}
