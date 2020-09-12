using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool DestroyPickupsOnPickup = true;

    public float destroyTime = 10f;

    // Start is called before the first frame update
     public void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        string collisionTag = collision.gameObject.tag;

        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            PickupBehaviour(collision);
            Destroy(gameObject);

            if (DestroyPickupsOnPickup)
            {
                DestroyOtherPickups();
            }
        }

    }

    public virtual void PickupBehaviour(Collider2D collision)
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
            Destroy(single_pickup.gameObject);
        }
    }
}
