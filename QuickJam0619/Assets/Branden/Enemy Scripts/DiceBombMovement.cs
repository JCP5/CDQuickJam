using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBombMovement : MonoBehaviour
{

    public float speed = 3f;
    public float explosionRadius = 1;
    public int damageDealt = 20;
    public float timer = 4.5f;

    private bool spawning = true;

    public GameObject explosionParticles;

    public Transform player;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if(spawning == false)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
                if (timer > 0)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer <= 0)
                {
                    Instantiate(explosionParticles, transform.position, Quaternion.identity);
                    Explode();
                    Destroy(this.gameObject);
                }
            }
        }
        catch
        {
            Debug.Log("Player Not Found");
        }
    }

    public void Explode()
    {
        Collider2D[] inExplosion = Physics2D.OverlapCircleAll(this.transform.position, explosionRadius);

        foreach (Collider2D col in inExplosion)
        {
            if (col.TryGetComponent(out PlayerHealth ph))//If col has the PlayerHealth script
            {
                ph.TakeDamage(damageDealt);
            }
            else //if col doesn't have the PlayerHealth script
            {
                //Stuff
            }
        }

        //deals damage to player/enemies?
    }

    public void SetSpawnFalse()
    {
        spawning = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Explode();
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        EnemyHealth enemyHealth = this.GetComponent<EnemyHealth>();
        float health = enemyHealth.Health;
        if (health <= 0)
        {
            Explode();
        }
    }
}
