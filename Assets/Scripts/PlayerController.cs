using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Mana")]
    public float maxMana = 100f;
    public float manaRegenRate = 5f;
    public float currentMana;

    [Header("Movimento")]
    public float jumpForce = 8f;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        currentMana = maxMana;
    }

    void Update() {
        // Regenera mana
        currentMana = Mathf.Min(maxMana, currentMana + manaRegenRate * Time.deltaTime);

        // Input de pulo
        if (Input.GetMouseButtonDown(0) && currentMana >= 20f) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentMana -= 20f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        }
    }
}