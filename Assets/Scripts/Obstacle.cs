using UnityEngine;

public class Obstacle : MonoBehaviour {
    private float speed;

    public void Initialize(float obstacleSpeed) {
        speed = obstacleSpeed;
    }

    void Update() {
        // Move obstáculo para a esquerda (simula subida do player)
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Despawn ao sair da tela
        if (transform.position.x < -15f) {
            Destroy(gameObject);
        }
    }
}