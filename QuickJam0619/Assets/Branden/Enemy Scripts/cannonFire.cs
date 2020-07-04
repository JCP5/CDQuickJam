using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonFire : MonoBehaviour
{
    public Transform firePoint;

    public Transform playerPos;

    public GameObject cannonBallPreFab;

    public float rotationSpeed = 2f;

    public float shotCoolDown = 1f;
    public float shotCoolDownTimer = 0f;

    public float shotForce = 10f;
    void Start()
    {
        shotCoolDownTimer = shotCoolDown;
    }

    void Update()
    {
        RotateTowards(playerPos.position);
        if(shotCoolDownTimer > 0)
        {
            shotCoolDownTimer -= Time.deltaTime;
        }

        if(shotCoolDownTimer <= 0)
        {
            FireCannon();
        }
    }

    private void FireCannon()
    {
        GameObject cannonBall = Instantiate(cannonBallPreFab , firePoint.position, firePoint.rotation);
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * shotForce, ForceMode2D.Impulse);
        shotCoolDownTimer = shotCoolDown;
    }

    private void RotateTowards(Vector2 playerPos)
    {
        var offset = 90f;
        Vector2 direction = playerPos - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
