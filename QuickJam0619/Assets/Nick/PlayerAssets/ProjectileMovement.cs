using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{

    private Vector2 target;
    private Vector2 playerPos;

    private Vector2 projectilePos;

    private Vector2 target_transform;

    private float x_velocity;
    private float y_velocity;

    private Vector2 projectile_velocity;
    private Vector2 projectile_direction;
    private float new_x;
    private float new_y;

    public float speed;

    public float projectileLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        //This part took me forever to understand, if you don't include a z value here it will always return the 
        //position of the 
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        projectile_velocity = target - playerPos;
        projectile_direction = projectile_velocity.normalized;

        Destroy(gameObject, projectileLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        projectilePos = transform.position;
        transform.position = projectilePos + (projectile_direction * speed * Time.deltaTime);
    }
}
