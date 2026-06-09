using UnityEngine;

public class Movement : MonoBehaviour
{
    static public Movement main;
    private Rigidbody2D rb;
    [SerializeField] private float walkSpeed = 1, jumpForce = 10;
    [SerializeField] private Transform groundPoint;

    private bool grounded;
    void Start()
    {
        main = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var horInput = Input.GetAxis("Horizontal");
        grounded = Physics2D.OverlapCircleAll(groundPoint.position, 0.1f).Length > 1;

        WalkHandler(horInput);

        JumpHandler();

        // conditional direction body flip
        FlipBodyHandler(horInput);
        
        // inject into address
        if (Input.GetKeyDown(KeyCode.Q)) Inject();
        
    }
    private void JumpHandler()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !grounded) return;

        // execution of jump
        rb.AddForceY(jumpForce);
    }
    private void Inject()
    {
        var animator = PlayerManager.instance.bodyAnimator;
        animator.Play("Inject");
        this.enabled = false;
    }
    private void WalkHandler(float horInput)
    {
        rb.linearVelocity = new Vector2(horInput * walkSpeed, rb.linearVelocity.y);

        var animator = PlayerManager.instance.bodyAnimator;

        float treshold = 0.2f;
        animator.SetBool("walk", Mathf.Abs(horInput) > treshold && grounded);
    }

    private void FlipBodyHandler(float horInput)
    {
        if (Mathf.Abs(horInput) > 0.01)
        {
            // float angle = horInput > 0 ? 0f : 180f;
            // PlayerManager.instance.body.transform.localEulerAngles = new Vector3(0, angle, 0);

            PlayerManager.instance.bodySprite.flipX = horInput < 0;
        }
    }
}
