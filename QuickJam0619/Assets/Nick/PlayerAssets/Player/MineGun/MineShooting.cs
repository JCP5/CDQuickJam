using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineShooting : ShootingBase
{

    public GameObject shot;

    public Vector3 offset;

    private Vector2 playerPos;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        ammoScript = gameObject.GetComponent<AmmoControl>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject createdShot;

        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

            createdShot = Instantiate(shot, playerPos, Quaternion.identity);
            createdShot.GetComponent<MineProjectileBehaviour>().Destination = target;

            FireShot();
        }
    }
}
