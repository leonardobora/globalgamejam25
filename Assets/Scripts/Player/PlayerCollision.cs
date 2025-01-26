using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("Tags")]
    public string obstacleTag = "Obstacle";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(obstacleTag))
        {
        Debug.Log("colozao");
            // Notifique o GameManager ou destrua o player
            Destroy(gameObject);
        }
    }
}