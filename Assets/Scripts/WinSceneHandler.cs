using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Listen for the spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the Main Scene when space is pressed
            SceneManager.LoadScene("MainScene");
        }
    }
}
