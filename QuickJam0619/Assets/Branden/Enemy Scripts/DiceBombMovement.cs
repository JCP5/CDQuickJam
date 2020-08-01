using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBombMovement : MonoBehaviour
{

    public float speed = 3f;
    public float explosionRadius = 1;
    public int damageDealt = 20;

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
            rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
        }
        catch
        {
            Debug.Log("Player Not Found");
        }
    }

    public void Explode()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        Collider2D[] inExplosion = Physics2D.OverlapCircleAll(this.transform.position, explosionRadius);
        
        foreach(Collider2D col in inExplosion)
        {
            if(col.TryGetComponent(out PlayerHealth ph))//If col has the PlayerHealth script
            {
                ph.TakeDamage(damageDealt);
            }
            else //if col doesn't have the PlayerHealth script
            {
                //Stuff
            }
        }

        Destroy(this.gameObject);
        //deals damage to player/enemies?
    }
}
