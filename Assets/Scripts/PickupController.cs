using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PickupController : MonoBehaviour
{
    [SerializeField] private int humanCount;
    [SerializeField] private int maxHumanCount = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            PickupHuman(other);
        }
        else if (other.CompareTag("Hospital"))
        {
            DropHumans(other);
        }
    }

    private void DropHumans(Collider2D other)
    {
        // TODO maybe do some fancy animation here for humans being dropped off
        
        GameManager.Instance.RescuedCount += humanCount;
        GameManager.Instance.PickedCount = 0;
        humanCount = 0;
    }

    private void PickupHuman(Collider2D other)
    {
        if (humanCount < maxHumanCount)
        {
            // Pickup the human...so destroy it
            Destroy(other.gameObject);
            humanCount++;
            GameManager.Instance.PickedCount++;
        }
    }
}