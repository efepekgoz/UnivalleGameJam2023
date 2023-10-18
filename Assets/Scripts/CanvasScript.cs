using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public PlayerMovement playerMovement; 
    public Text healthText; 
    public BallBuster ballBuster;
    public Text scoreText;

    public AudioClip themeSong; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent < AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject");
            return;
        }
  
        audioSource.clip = themeSong;
        audioSource.volume = audioSource.volume * 0.5f;
        audioSource.Play();
    }

    void Update()
    {
        if (playerMovement != null && healthText != null)
        {
            healthText.text = playerMovement.Health.ToString();
        }
        if (ballBuster != null && scoreText != null)
        {
            scoreText.text = "Score: " + ballBuster.score.ToString();
        }


    }

}
