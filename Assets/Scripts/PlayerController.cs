using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    public float smoothTime = 0.1f; // Added smoothing for movement

    private float Move;
    private Vector2 velocity = Vector2.zero; // Used for smooth movement

    public Rigidbody2D rb;
    public bool isJumping;

    public AudioSource audioSource;
    public AudioClip jumpSound;

    private Camera mainCamera;

    // Cache the last horizontal input for flipping
    private float lastMove;

    void Start()
    {
        mainCamera = Camera.main;
        lastMove = 0f; // Initialize lastMove to 0
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        // Apply smooth movement
        Vector2 targetVelocity = new Vector2(speed * Move, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, smoothTime);

        // Flip sprite based on movement direction, but only if the direction has changed
        if (Move > 0 && lastMove <= 0) // Moving right, but last move was left
        {
            transform.localScale = new Vector3(2f, 2f, 2f); // Flip sprite to face right
        }
        else if (Move < 0 && lastMove >= 0) // Moving left, but last move was right
        {
            transform.localScale = new Vector3(-2f, 2f, 2f); // Flip sprite to face left
        }

        lastMove = Move; // Update the last move direction

        // Jumping logic
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0, jump));

            // Play the jump sound effect
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        ConstrainPlayerPosition();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }

    private void ConstrainPlayerPosition()
    {
        // Get the camera bounds
        float cameraLeftBound = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        float cameraRightBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        Vector3 playerPos = transform.position;

        // Constrain player on the x-axis
        playerPos.x = Mathf.Clamp(playerPos.x, cameraLeftBound, cameraRightBound);

        transform.position = playerPos;
    }
}