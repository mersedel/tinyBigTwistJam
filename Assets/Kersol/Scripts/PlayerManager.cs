using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance;
    public GameObject body;
    [HideInInspector] public Animator bodyAnimator;

    void Awake() {
        instance = this;
        bodyAnimator = body.GetComponent<Animator>();
        CameraFollow.main.target = transform;
    }
}
