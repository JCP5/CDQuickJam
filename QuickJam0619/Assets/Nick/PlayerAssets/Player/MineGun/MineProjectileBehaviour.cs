using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectileBehaviour : MonoBehaviour
{

    public Vector2 Destination;
    public float ProjectileSpeed;
    public GameObject explosionPrefab;

    public int DamageDealt;

    public float Lifetime;

    public Vector2 MineScale;
    public float ExplosionSize;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = MineScale;
        Destroy(gameObject, Lifetime);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Destination, ProjectileSpeed);

        if (Input.GetMouseButtonDown(1))
        {
            Explode();
        }
    }

    void Explode()
    {

        foreach (Collider2D currentCollider in Physics2D.OverlapCircleAll(transform.position, ExplosionSize))
        {

            if (currentCollider.GetComponent<EnemyHealth>() != null)
            {
                currentCollider.GetComponent<EnemyHealth>().TakeDamage(DamageDealt);
            }
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
