using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBeamShooting : ShootingBase
{

    public GameObject shot;

    public float ChargeTime;

    public float BeamSize;

    public int DamageDealt;

    private float remainingChargeTime;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        remainingChargeTime = ChargeTime;

        ammoScript = gameObject.GetComponent<AmmoControl>();
    }

    // Update is called once per frame
    void Update()
    {

        UniversalUpdateBehaviour();

        if (Input.GetMouseButton(0) && CanShoot())
        {
            if (remainingChargeTime <= 0)
            {
                target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

                Instantiate(shot, target, Quaternion.identity);

                foreach (Collider2D currentCollider in Physics2D.OverlapCircleAll(target, BeamSize))
                {
                    if (currentCollider.GetComponent<EnemyHealth>() != null)
                    {
                        currentCollider.GetComponent<EnemyHealth>().TakeDamage(DamageDealt);
                    }
                }

                FireShot();

                remainingChargeTime = ChargeTime;
            }
            else
            {
                remainingChargeTime = remainingChargeTime - Time.deltaTime;
            }
        }
        else
        {
            remainingChargeTime = ChargeTime;
        }
    }

}
