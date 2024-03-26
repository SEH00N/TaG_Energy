using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] float gravityScale = 1f;

    [Header("Ground Check")]
    [SerializeField] LayerMask groundLayer = 0;
    [SerializeField] float groundThreshold = 0.5f;

    private float verticalVelocity = 0f;
    private bool isGround = false;
    public bool IsGround => isGround;

    private Vector3 velocity = Vector3.zero;
    public Vector3 Velocity => velocity;

    private CharacterController characterController = null;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

	private void FixedUpdate()
    {
        isGround = characterController.isGrounded | CheckGround();
        if(isGround && verticalVelocity < 0f)
            ApplyGravity(Time.fixedDeltaTime, 0.3f);
        else
            ApplyGravity(Time.fixedDeltaTime, 1f);

        ApplyVelocity(Time.fixedDeltaTime);
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void SetVerticalVelocity(float velocity)
    {
        verticalVelocity = velocity;
    }

    private bool CheckGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundThreshold, groundLayer);
    }

    private void ApplyGravity(float deltaTime, float scale = 1f)
    {
        verticalVelocity += Physics.gravity.y * gravityScale * deltaTime * scale;
        velocity.y = verticalVelocity;
    }

    private void ApplyVelocity(float deltaTime)
    {
        characterController.Move(velocity * deltaTime);
    }
}
