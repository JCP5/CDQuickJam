using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonFire : MonoBehaviour
{
    public AudioSource audSource;
    public AudioClip clip;

    public Transform firePoint;

    public Transform playerPos;

    public GameObject cannonBallPreFab;
    public GameObject deathParticle;

    public float rotationSpeed = 2f;

    public float shotCoolDown = 1f;
    public float shotCoolDownTimer = 0f;

    private bool spawning = true;

    public float shotForce = 10f;

    private Animator cannonAnimator;
    void Start()
    {
        shotCoolDownTimer = shotCoolDown;
        playerPos = FindObjectOfType<Player>().transform;
        cannonAnimator = GetComponent<Animator>();
        audSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        try
        {
            RotateTowards(playerPos.position);
        }
        catch
        {
            return;
        }

        if(shotCoolDownTimer > 0)
        {
            shotCoolDownTimer -= Time.deltaTime;
        }

        if(shotCoolDownTimer <= 0)
        {
            cannonAnimator.SetTrigger("Fire");
            shotCoolDownTimer = shotCoolDown;
        }
    }

    public void FireCannon()
    {
        PlaySound();
        GameObject cannonBall = Instantiate(cannonBallPreFab , firePoint.position, firePoint.rotation);
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
        rb.AddForce(-firePoint.up * shotForce, ForceMode2D.Impulse);
        cannonAnimator.SetTrigger("Idle");
    }

    public void SetSpawnFalse()
    {
        spawning = false;
    }

    private void RotateTowards(Vector2 playerPos)
    {
        var offset = 90f;
        Vector2 direction = playerPos - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
    }

    public void PlaySound()
    {
        audSource.clip = clip;
        audSource.Stop();
        audSource.Play();
    }
}
