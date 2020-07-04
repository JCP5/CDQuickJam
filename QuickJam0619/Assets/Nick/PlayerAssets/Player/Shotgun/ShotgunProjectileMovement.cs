using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectileMovement : MonoBehaviour
{

    public float adjustmentAngle;
    public float speed;
    public float projectileLifeTime;

    private Vector2 target;
    private Vector2 playerPos;
    private Vector2 projectilePos;

    private Vector2 projectileVelocity;
    private Vector2 projectileDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        projectileVelocity = target - playerPos;
        projectileDirection = projectileVelocity.normalized;
        projectileDirection = Rotate(projectileDirection, adjustmentAngle);

        float angle = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Destroy(gameObject, projectileLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        projectilePos = transform.position;
        transform.position = projectilePos + (projectileDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    // Rotate a vector by given degrees
    public static Vector2 Rotate(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);

        float tx = v.x;
        float ty = v.y;

        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }
}
