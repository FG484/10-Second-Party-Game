using UnityEngine;
using UnityEngine.UI;  // For UI components

public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 10f; // Set initial time to 10 seconds
    public Text timerText;            // Reference to the Text component to display the timer

    private bool isCountingDown = true;
    private bool isTimeUp = false;  // Flag to check if time is up

    // Start is called before the first frame update
    void Start()
    {
        // Check if the timerText is assigned
        if (timerText == null)
        {
            Debug.LogError("TimerText not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only count down if the timer is active
        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;  // Decrease time by the time passed since last frame

            // Update the timer text
            timerText.text = Mathf.Ceil(timeRemaining).ToString(); // Round up the time to the nearest whole number

            // Check if time is up
            if (timeRemaining <= 0f && !isTimeUp)
            {
                isCountingDown = false;
                timeRemaining = 0f; // Make sure time doesn't go below 0
                timerText.text = "Time's up!"; // Display message when time is up

                isTimeUp = true; // Set flag so we only trigger the transition once
                // Load the Win Scene here (add scene loading code to transition to the win scene)
                UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
            }
        }
    }
}