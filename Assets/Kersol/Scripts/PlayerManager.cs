using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance;
    public GameObject body;
    public SpriteRenderer bodySprite;
    public DigitController digitController;
    [HideInInspector] public Animator bodyAnimator;

    void Awake() {
        instance = this;
        bodyAnimator = body.GetComponent<Animator>();
        bodySprite = body.GetComponent<SpriteRenderer>();
        CameraFollow.main.target = transform;

        digitController.randomizeDigits();
    }
}
