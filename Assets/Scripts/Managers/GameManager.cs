using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float speedmult;
    public float vertical_speed{get;private set;}

    public void SetSpeed(float newspeed){
        vertical_speed = newspeed * speedmult;
    }
    public static GameManager Instance() => instance;

    private static GameManager instance;

    [Header("UI")]
    public GameObject gameOverPanel;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        Time.timeScale = 0; // Pausa o jogo
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}