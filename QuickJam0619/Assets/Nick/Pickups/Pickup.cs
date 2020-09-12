using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool DestroyPickupsOnPickup = true;

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
        if (DestroyPickupsOnPickup)
        {
            DestroyOtherPickups();
        }
    }

    public void DestroyOtherPickups()
    {
        Object[] other_pickups;

        other_pickups = FindObjectsOfType(typeof(Pickup));

        foreach (Pickup single_pickup in other_pickups)
        {
            Destroy(single_pickup);
        }
    }
}
