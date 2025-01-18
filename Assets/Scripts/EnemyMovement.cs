using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed at which the enemy moves
    public float leftBound = -10f; // X position where the enemy is off-screen
    public GameObject particleEffectPrefab; // Reference to the particle effect prefab

    private GameObject particleEffectInstance; // Reference to the particle effect instance

    void Start()
    {
        if (particleEffectPrefab != null)
        {
            // Instantiate the particle effect behind the enemy at the start
            particleEffectInstance = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            // Make sure the particle effect follows the enemy by setting it as a child
            particleEffectInstance.transform.SetParent(transform);
            // Adjust the position to the right side of the enemy
            particleEffectInstance.transform.localPosition = new Vector3(1f, 0f, 0f); // Set to the right of the enemy
        }
    }

    void Update()
    {
        // Move the enemy to the left
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // Ensure the particle effect follows the enemy
        if (particleEffectInstance != null)
        {
            particleEffectInstance.transform.position = transform.position + new Vector3(1f, 0f, 0f); // Update position to be on the right side
        }

        // Check if the enemy has gone off-screen and destroy it
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject); // Destroy the enemy when it goes out of bounds
            if (particleEffectInstance != null)
            {
                Destroy(particleEffectInstance); // Optionally destroy the particle effect as well
            }
        }
    }

    // Trigger method to detect collision with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Check if the colliding object is the player
        {
            Destroy(other.gameObject);  // Destroy the player when they collide with the enemy
            // Call the method to handle the lose scenario
            HandlePlayerDeath();
        }
    }

    // Method to handle when the player dies
    private void HandlePlayerDeath()
    {
        // Transition to the LoseScene immediately after the player is destroyed
        SceneManager.LoadScene("LoseScene");
    }

    // Coroutine to handle a delayed scene transition (optional)
    private IEnumerator TransitionToLoseSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Delay of 1 second before transition
        SceneManager.LoadScene("LoseScene");
    }
}
