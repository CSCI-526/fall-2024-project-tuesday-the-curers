using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 20; // The amount of health this pickup gives.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player touched the object.
        {
            playerState health = other.GetComponent<playerState>(); // Get the PlayerHealth script.

            if (health != null)
            {
                health.AddHealth(healthAmount); // Add health to the player.
                Destroy(gameObject); // Destroy the health pickup after it¡¯s collected.
                PickupCount.Instance.count++;
            }
        }
    }
}
