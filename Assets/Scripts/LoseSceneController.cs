using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class LoseSceneController : MonoBehaviour
{
    void Update()
    {
        // Check for spacebar input to return to the main scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene"); // Replace with your main scene name
        }
    }
}