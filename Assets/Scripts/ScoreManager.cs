using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start() {
        InvokeRepeating("IncreaseScore", 1f, 1f);
    }

    void IncreaseScore() {
        score++;
        scoreText.text = "Score: " + score;
    }
}