﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkmovement : MonoBehaviour
{
    public float speed = 2.5f;

    public float attackCoolDown = 1.5f;
    public float attackCoolDownTimer = 0f;

    public Vector3 playerRelativePosition;
    public Transform player;
    public bool moving;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackCoolDownTimer = attackCoolDown;
        moving = false;
    }

    void FixedUpdate()
    {
        playerRelativePosition = transform.InverseTransformPoint(player.position);

        if (attackCoolDownTimer < 0)
        {
            attackCoolDownTimer = 0;
        }

        if (attackCoolDownTimer > 0 && moving == false)
            attackCoolDownTimer -= Time.deltaTime;

         if(attackCoolDownTimer == 0)
        {
            moving = true;

            if (playerRelativePosition.x > 0.02 && playerRelativePosition.y > 0.02) //moving up+right
                StartCoroutine("MoveUpRight");
            else if (playerRelativePosition.x > 0.02 && playerRelativePosition.y < -0.02) //moving down+right
                StartCoroutine("MoveDownRight");            
            else if (playerRelativePosition.x < -0.02 && playerRelativePosition.y < -0.02) //moving down+left
                StartCoroutine("MoveDownLeft");
            else if (playerRelativePosition.x < -0.02 && playerRelativePosition.y > 0.02) //up+left
                StartCoroutine("MoveUpLeft");
            else if ((playerRelativePosition.x < 0.02 && playerRelativePosition.x > -0.02) || (playerRelativePosition.y < 0.02 && playerRelativePosition.y > -0.02)) //dont move
                DontMove();
            else
            {
                DontMove();
            }

        }
    }

    IEnumerator MoveUpLeft()
    {
        moving = false;
        attackCoolDownTimer = attackCoolDown;
        rb.velocity = new Vector2(-1,1) * speed;

        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(0, 0);
    }

    IEnumerator MoveUpRight()
    {
        moving = false;
        attackCoolDownTimer = attackCoolDown;
        rb.velocity = new Vector2(1, 1) * speed;

        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(0, 0);
    }

    IEnumerator MoveDownLeft()
    {
        moving = false;
        attackCoolDownTimer = attackCoolDown;
        rb.velocity = new Vector2(-1, -1) * speed;

        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(0, 0);
    }

    IEnumerator MoveDownRight()
    {
        moving = false;
        attackCoolDownTimer = attackCoolDown;
        rb.velocity = new Vector2(1, -1) * speed;

        yield return new WaitForSeconds(.5f);
        rb.velocity = new Vector2(0, 0);
    }

    private void DontMove()
    {
        moving = false;
        attackCoolDownTimer = attackCoolDown;
    }
}