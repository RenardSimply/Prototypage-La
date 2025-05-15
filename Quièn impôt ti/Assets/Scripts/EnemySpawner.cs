using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject enemyPrefab;
    public float initialSpawnRate = 2;
    public float minimumSpawnRate = 0.4f;
    public float spawnAcceleration = 0.05f;
    public float spawnHeight = -4.55f;
    public Transform leftSpawnPosition;
    public Transform rightSpawnPosition;

    private float currentSpawnRate;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnRate = initialSpawnRate;

        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        //if (timer > initialSpawnRate)
        //{
        //    float randomX = Random.Range(-9, 9);
        //    Vector3 randomPosition = new Vector3(randomX, spawnHeight, 0);

        //    GameObject spawnedEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        //    Enemy enemy = spawnedEnemy.GetComponent<Enemy>();
        //    enemy.gameManager = gameManager;

        //    timer = timer - initialSpawnRate;
        //}
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int random = Random.Range(0, 2);
            GameObject spawnedEnemy;

            if (random == 0)
            {
                 spawnedEnemy = Instantiate(enemyPrefab, leftSpawnPosition.position, Quaternion.identity);
            }

            else
            {
                 spawnedEnemy = Instantiate(enemyPrefab, rightSpawnPosition.position, Quaternion.identity);
            }

            Enemy enemy = spawnedEnemy.GetComponent<Enemy>();
            enemy.gameManager = gameManager;
            currentSpawnRate = Mathf.Max(minimumSpawnRate, currentSpawnRate - spawnAcceleration);

            yield return new WaitForSeconds(currentSpawnRate);
        }
    }
}
