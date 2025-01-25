using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;

    [Header("SFX")]
    public AudioClip gameOverSFX;

    private AudioSource audioSource;

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGameOverSFX() {
        audioSource.PlayOneShot(gameOverSFX);
    }
}