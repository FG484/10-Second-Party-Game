using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip backgroundMusic;  // Reference to the background music clip
    private AudioSource audioSource;    // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if the background music is assigned and if there's no AudioSource already playing the music
        if (backgroundMusic != null && audioSource != null)
        {
            audioSource.clip = backgroundMusic;  // Set the background music clip
            audioSource.loop = true;  // Loop the music so it plays continuously
            audioSource.Play();  // Play the music when the game starts
        }
        else
        {
            Debug.LogError("Background music or AudioSource is not assigned!");
        }
    }
}