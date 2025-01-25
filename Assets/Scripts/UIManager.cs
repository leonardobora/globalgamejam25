using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI manaText;
    public GameObject gameOverPanel;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update() {
        // Atualiza UI em tempo real
        scoreText.text = $"Score: {GameManager.Instance.Score:F0}";
        manaText.text = $"Mana: {FindFirstObjectByType<PlayerController>().currentMana:F0}";
    }

    public void ShowGameOver(float finalScore) {
        gameOverPanel.SetActive(true);
        // Exibe pontuação final (adicione um TextMeshProUGUI adicional se necessário)
    }
}