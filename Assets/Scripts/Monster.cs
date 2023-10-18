using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int Damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.TakeDamage(Damage);
                Destroy(gameObject);
            }
        }else if (gameObject.CompareTag(other.tag))
        {
            Destroy(gameObject);
        }
    }
}
