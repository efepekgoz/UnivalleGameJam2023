using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int Health = 100;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for movement in the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;

        // Apply the movement to the Rigidbody2d
        rb.velocity = movement;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
           //Time.timeScale = 0f;
        }
    }
}
