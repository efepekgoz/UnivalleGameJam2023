using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBuster : MonoBehaviour
{
    public int score=0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag(other.tag))
        {
            Destroy(gameObject);
            score = score + 100;
        }
    }
}
