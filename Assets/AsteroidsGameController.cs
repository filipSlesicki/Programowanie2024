using UnityEngine;

public class AsteroidsGameController : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public Transform player;
    public float spawnInterval;
    private float spawnTimer;
    private Vector3 moveDirection;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAsteroid()
    {
        Vector3 spawnPositon = Random.insideUnitCircle.normalized * 20;
        Asteroid asteroid = Instantiate(asteroidPrefab, spawnPositon, Quaternion.identity);
        asteroid.LaunchTowards(player.position);
    }
}
