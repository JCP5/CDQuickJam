using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        string collisionTag = collision.gameObject.tag;

        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PickupBehaviour(collision);
        }

        Destroy(gameObject);
    }

    public virtual void PickupBehaviour(Collision2D collision)
    {

    }
}
