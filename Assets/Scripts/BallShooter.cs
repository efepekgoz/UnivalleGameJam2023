using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;      
    public Transform shootPoint;       // The point where the balls will be shot from
    public float shootForce = 10.0f;   
    public float ballLifetime = 4.0f; 
    private int shotsFired = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBallTowardsCursor();
            shotsFired++;

            // Change color every 8 shots
            if (shotsFired % 8 == 0)
            {
                ChangeBallColor();
            }
        }
    }

    void ShootBallTowardsCursor()
    {
        if (ballPrefab != null && shootPoint != null)
        {
            // Get cursor position
            Vector3 cursorPosition = Input.mousePosition;

            // Convert the cursor position to world space using the main camera
            Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
            worldCursorPosition.z = 0f; 

            GameObject newBall = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = newBall.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Shoot Direction
                Vector2 shootDirection = (worldCursorPosition - shootPoint.position).normalized;

                // Apply force
                rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
            }

            Destroy(newBall, ballLifetime);
        }
    }
    void ChangeBallColor()
    {
        if (ballPrefab != null)
        {
            SpriteRenderer spriteRenderer = ballPrefab.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                Color randomColor = GetRandomColor();
                spriteRenderer.color = randomColor;

                // Set the ball's tag based on its color
                if (randomColor == Color.red)
                {
                    ballPrefab.tag = "Red";
                }
                else if (randomColor == Color.blue)
                {
                    ballPrefab.tag = "Blue";
                }
                else if (randomColor == Color.yellow)
                {
                    ballPrefab.tag = "Yellow";
                }
            }
        }
    }

    Color GetRandomColor()
    {
        Color[] possibleColors = { Color.red, Color.blue, Color.yellow };
        return possibleColors[Random.Range(0, possibleColors.Length)];
    }



}

