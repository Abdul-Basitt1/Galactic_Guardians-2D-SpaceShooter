using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateIncreaseMAX : MonoBehaviour
{
    public float fireRateIncreaseAmount = 0.0f; // Adjust this value as needed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Power-up collected by the player!");

            // Get the ShootingScript component from the player
            ShootingController shootingScript = other.GetComponent<ShootingController>();

            if (shootingScript != null)
            {
                Debug.Log("ShootingScript found on player!");

                // Increase the fire rate of the player's shooting
                shootingScript.fireRate = fireRateIncreaseAmount;

                Debug.Log("Fire rate increased!");
            }
            else
            {
                Debug.Log("ShootingScript not found on player!");
            }

            // Destroy the power-up GameObject
            Destroy(gameObject);
        }
    }
}
