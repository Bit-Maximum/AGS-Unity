using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class KinematicTest : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementInput;
    private RaycastHit2D raycast;

    [SerializeField] private int speed = 10;
    [SerializeField] private int jumpForce = 20;
    [SerializeField] private int runAngleLimit = 60;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private BoxCollider2D groundCollider;
    [SerializeField] private ContactFilter2D groundFilter;

    [Header("Gravity settings")]

    private bool isJump;
    private bool onGround;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<BoxCollider2D>();
        isJump = false;
    }

    private void Start()
    {
        groundFilter.SetLayerMask(groundMask);

    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            body.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            isJump = false;
        }

        body.AddForce(movementInput * speed);
        //body.MovePosition(body.position + body.velocity);
    }

    public void OnJump(InputValue inputValue)
    {
        isJump = true;
    }

    public void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
        if (movementInput.y > 0)
            isJump = true;
    }

    private void Grounded()
    {
        Collider2D[] colliders = new Collider2D[16];
        var count = groundCollider.OverlapCollider(groundFilter, colliders);
        onGround = count > 0;
    }
}
