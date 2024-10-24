using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private CircleCollider2D collider;
    private Vector2 movementInput;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float jumpForse = 10;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnMove(InputValue value)
    {
        movementInput.x = value.Get<Vector2>().normalized.x * speed;
        Debug.Log(movementInput);

        if (value.Get<Vector2>().normalized.y > 0 || Input.GetKeyDown(KeyCode.Space)) { Jump(); }
    }

    private void FixedUpdate()
    {
        body.AddForce(movementInput);
    }

    private void Jump()
    {
        Debug.Log(IsGrounded());
        if (IsGrounded())
        {
            movementInput.y = jumpForse;
            body.AddForce(movementInput);
        }
    }

    bool IsGrounded()
    {
        return body.IsTouching(collider);
    }

}


public interface AbilityBehavior
{
    public void PerformAbility();
}
