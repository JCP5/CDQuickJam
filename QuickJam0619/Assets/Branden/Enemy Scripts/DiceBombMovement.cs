using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBombMovement : MonoBehaviour
{

    public float speed = 3f;

    public GameObject explosionParticles;

    public Transform player;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
    }

    public void Explode()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        //deals damage to player/enemies?
    }
}
