using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnScript : MonoBehaviour
{
    public GameObject[] monsterPrefabs; 

    public Transform player;         
    public float spawnRadius = 5f;  // Radius of the circular spawn area
    public float spawnInterval = 2f; // Time interval between each spawn
    public int maxMonsters = 10;     
    public float moveSpeed = 3f;    

    private int monstersSpawned = 0;

    private void Start()
    {
        StartCoroutine(SpawnMonsters());  
    }

    private IEnumerator SpawnMonsters()
    {
        while (monstersSpawned < maxMonsters)
        {
            // Calculate a random angle within the circle (in radians).
            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

            // Calculate the spawn position
            float spawnX = player.position.x + spawnRadius * Mathf.Cos(randomAngle);
            float spawnY = player.position.y + spawnRadius * Mathf.Sin(randomAngle);

            // Create a Vector2 for the spawn position.
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

            // Select a random monster
            GameObject selectedMonsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

            // Instantiate the monster at the calculated location
            GameObject monster = Instantiate(selectedMonsterPrefab, spawnPosition, Quaternion.identity);

            StartCoroutine(MoveTowardsPlayer(monster));

            monstersSpawned++;

            // Wait for the next spawn
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    private IEnumerator MoveTowardsPlayer(GameObject monster)
    {
        while (monster != null && player != null)
        {
            Vector2 direction = (player.position - monster.transform.position).normalized;
            monster.transform.Translate(direction * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
