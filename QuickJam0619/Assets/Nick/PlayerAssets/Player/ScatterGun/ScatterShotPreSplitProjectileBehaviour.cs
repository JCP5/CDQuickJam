using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterShotPreSplitProjectileBehaviour : MonoBehaviour
{
    public float speed;

    public float projectileLifeTime;

    public int SplitProjectileCount;

    public float SplitSpawnOffset;

    public GameObject SplitShot; 

    private Vector2 target;
    private Vector2 playerPos;

    private Vector2 projectilePos;

    private Vector2 projectileVelocity;
    private Vector2 projectileDirection;


    private int splitAngle;
    private Vector2 newProjectileDirection;
    private GameObject splitBullet;

    private Vector2 spawnLocation; 

    // Start is called before the first frame update
    void Start()
    {
        //This part took me forever to understand, if you don't include a z value here it will always return the 
        //position of the camera
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        projectileVelocity = target - playerPos;
        projectileDirection = projectileVelocity.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        projectilePos = transform.position;
        transform.position = projectilePos + (projectileDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Split the projectile
        splitAngle = 360 / SplitProjectileCount;

        for (int i = 0; i < SplitProjectileCount; i++)
        {

            newProjectileDirection = Rotate(projectileDirection, splitAngle * i);
            projectilePos = transform.position;
            spawnLocation = projectilePos + (newProjectileDirection * SplitSpawnOffset);
            splitBullet = Instantiate(SplitShot, spawnLocation, Quaternion.identity);
            splitBullet.GetComponent<ScatterShotProjectilePostSplitBehaviour>().projectileDirection = newProjectileDirection;

        }

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
