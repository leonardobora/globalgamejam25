using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public GameObject[] obstaclePrefabs;
    public float spawnRate = 2f;
    public float minY = -3f, maxY = 3f;

    void Start() {
        InvokeRepeating("SpawnObstacle", 1f, spawnRate);
    }

    void SpawnObstacle() {
        int index = Random.Range(0, obstaclePrefabs.Length);
        float yPos = Random.Range(minY, maxY);
        Instantiate(obstaclePrefabs[index], new Vector2(10f, yPos), Quaternion.identity);
    }
}