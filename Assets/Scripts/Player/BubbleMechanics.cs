using UnityEngine;

public class BubbleMechanic : MonoBehaviour
{
    [Header("Bubble Settings")]
    public float maxBubbleSize = 3f;
    public float minBubbleSize = 0.1f;
    public float growthSpeed = 1f;
    public float decaySpeed = 0.5f;
    public Transform bubbleVisual; // Objeto filho com SpriteRenderer


    [Header("Propulsion")]
    public float propulsionForce = 10f;
    [Range(1f, 10f)]
    public float gravoffset;

    private float currentBubbleSize;
    private bool isInflating;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentBubbleSize = transform.localScale.x;
    }

    void Update()
    {
        HandleBubbleInput();
        UpdateBubbleVisual();
        CheckForExplosion();
        Debug.Log(currentBubbleSize);
        SetGravitySpeed();
    }
private void SetGravitySpeed(){
    GameManager.Instance().SetSpeed(-(currentBubbleSize - gravoffset));
}
    private void HandleBubbleInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBubbleSize += growthSpeed * Time.deltaTime;
            isInflating = true;
        }
        else
        {
            currentBubbleSize -= decaySpeed * Time.deltaTime;
            isInflating = false;
        }

        currentBubbleSize = Mathf.Clamp(currentBubbleSize, minBubbleSize, maxBubbleSize);
    }

    private void UpdateBubbleVisual()
    {
        if (bubbleVisual != null)
            bubbleVisual.localScale = Vector3.one * currentBubbleSize;
    }

    private void CheckForExplosion()
    {
        if (currentBubbleSize >= maxBubbleSize || currentBubbleSize <= minBubbleSize)
        {
        Debug.Log("CheckForExplosion");
            // Chame o GameOver do GameManager aqui
            Destroy(gameObject); // Exemplo simples
        }
    }

    public void ApplyPropulsion()
    {
        if (isInflating)
        {
            rb.AddForce(Vector2.up * propulsionForce, ForceMode2D.Impulse);
            currentBubbleSize = minBubbleSize; // Reset
        }
    }
}