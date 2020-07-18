using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectileBehaviour : MonoBehaviour
{

    public float Speed;

    public float TurnRate;

    public float ProjectileLifeTime;

    public int DamageDealt;

    Rigidbody2D homingRigidbody;

    private Vector2 target;
    private Vector2 bulletLocation;
    private Vector2 playerPos;
    private Vector2 projectileVelocity;
    private Vector2 projectileDirection;

    // Start is called before the first frame update
    void Start()
    {
        //This part took me forever to understand, if you don't include a z value here it will always return the 
        //position of the camera
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        projectileVelocity = target - playerPos;
        projectileDirection = projectileVelocity.normalized;

        float angle = Mathf.Atan2(projectileDirection.y, projectileDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        homingRigidbody = GetComponent<Rigidbody2D>();

        //Despawn the projectile after a little while
        Destroy(gameObject, ProjectileLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DamageDealt);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        bulletLocation = transform.position;

        transform.right = Vector2.Lerp(transform.right, (target - bulletLocation), TurnRate);

        transform.position += transform.right * Speed * Time.deltaTime;
    }
}
