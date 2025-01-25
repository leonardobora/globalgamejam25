using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [Header("Obstáculos")]
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 2f;
    public float obstacleSpeed = 5f;
    public float speedIncreaseRate = 0.1f;

    [Header("Pontuação")]
    private float score;
    public float Score => score;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start() {
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval);
    }

    void Update() {
        // Atualiza pontuação baseada no tempo
        score += Time.deltaTime;
        // Aumenta velocidade progressivamente
        obstacleSpeed += speedIncreaseRate * Time.deltaTime;
    }

    void SpawnObstacle() {
        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject obstacle = Instantiate(obstaclePrefabs[index], new Vector2(10f, Random.Range(-3f, 3f)), Quaternion.identity);
        obstacle.GetComponent<Obstacle>().Initialize(obstacleSpeed);
    }

    public void GameOver() {
        // Comunica com UIManager e SoundManager
        UIManager.Instance.ShowGameOver(score);
        SoundManager.Instance.PlayGameOverSFX();
        Time.timeScale = 0;
    }
}