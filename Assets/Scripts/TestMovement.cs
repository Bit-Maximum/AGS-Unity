using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementInput;

    [SerializeField] private float groundSpeed = 10;
    [SerializeField] private float jumpForce = 100;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        movementInput.x = 0f;
        movementInput.y = 0f;
    }

    private void FixedUpdate()
    {
        body.AddForce(movementInput);
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("On Move " + value);
        float x = value.Get<Vector2>().x;
        float y = value.Get<Vector2>().y;


        //body.velocity += new Vector2(x * groundSpeed, body.velocity.y);
        movementInput.x = x * groundSpeed;
        if (y > 0) { Jump(); }
    }

    private void OnJump(InputValue value)
    {
        Debug.Log("On Jump " + value);
        Jump();
    }

    private void OnFire(InputValue value)
    {
        Debug.Log("On Fire " + value);
    }


    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity += new Vector2(body.velocity.x, jumpForce);
        }
    }

    private bool isGrounded()
    {
        return true;
    }
}
