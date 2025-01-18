using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // Necessary for UI Text component

public class TextDisappears : MonoBehaviour
{
    public Text textComponent;  // Reference to Unity UI Text component
    public AudioSource audioSource;  // Reference to the AudioSource component
    public AudioClip soundEffect;  // Reference to the sound effect to play

    void Start()
    {
        // Start the coroutine to display the text and play the sound
        StartCoroutine(ShowTextWithSound());
    }

    private IEnumerator ShowTextWithSound()
    {
        // Enable the text and play the sound
        textComponent.enabled = true;
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect); // Play the sound when the text appears
        }

        // Wait for the specified delay time (3 seconds)
        yield return new WaitForSeconds(3f);

        // Hide the text by disabling the Text component
        textComponent.enabled = false;
    }
}