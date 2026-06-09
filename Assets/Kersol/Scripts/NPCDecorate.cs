using UnityEngine;

public class NPCDecorate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Gradient gradient;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        PaintBody();
    }
    void PaintBody() => spriteRenderer.color = gradient.Evaluate(Random.Range(0f,1f));
}
