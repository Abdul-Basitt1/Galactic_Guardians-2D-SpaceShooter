using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateIncreasePowerUp : MonoBehaviour
{
    public float fireRateIncreaseAmount = 0.0f; // Adjust this value as needed
    public AudioClip powerUpSoundEffect; // Assign the power-up sound effect in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        Debug.Log("PowerUP Audio Found");
        audioSource.clip = powerUpSoundEffect;
    }

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

            if (audioSource != null && powerUpSoundEffect != null)
            {
                Debug.Log("PowerUP Audio Picked");
                audioSource.Play();
            }

            // Destroy the power-up GameObject
            Destroy(gameObject);
        }
    }
}
