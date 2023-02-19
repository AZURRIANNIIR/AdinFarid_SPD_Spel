using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathRespawn : MonoBehaviour
{
    public Transform respawnPoint; // The position where the player will respawn

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            // Trigger the death and respawn logic
            transform.position = respawnPoint.position;
        }
    }
}
