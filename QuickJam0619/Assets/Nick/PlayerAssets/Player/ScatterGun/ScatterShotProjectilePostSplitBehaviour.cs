using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterShotProjectilePostSplitBehaviour : MonoBehaviour
{
    public int DamageDealt;

    public Vector2 projectileDirection;

    public float speed;

    private Vector2 projectilePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        projectilePos = transform.position;
        transform.position = projectilePos + (projectileDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(DamageDealt);
        }



        Destroy(gameObject);
    }
}
