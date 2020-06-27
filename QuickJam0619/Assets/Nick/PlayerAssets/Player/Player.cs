using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int health;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        Debug.Log(health);

        if (health <= 0)
        {
            Debug.Log("YOU DIED");
        }

    }

    private void SwitchWeapon()
    {

    }

}
