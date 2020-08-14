using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBeamProjectileBehaviour : MonoBehaviour
{
    //public float LifeTime;
    float BeamSize;
    public int DamageDealt;
    Player player;
    TargetBeamShooting tbs;

    public GameObject explosionPrefab;
    public int explosionScale;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        tbs = player.GetComponent<TargetBeamShooting>();
        BeamSize = tbs.BeamSize;
        DamageDealt = tbs.DamageDealt;

        //Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(this.gameObject);
        }
        FollowCursor();
    }

    void FollowCursor()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    //Animation Event
    public void TargetBeamExplosion()
    {
        tbs.FireShot();

        Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);

        foreach (Collider2D currentCollider in Physics2D.OverlapCircleAll(transform.position, BeamSize))
        {
            if (currentCollider.GetComponent<EnemyHealth>() != null)
            {
                currentCollider.GetComponent<EnemyHealth>().TakeDamage(DamageDealt);
            }
        }

        Destroy(this.gameObject);
    }
}
