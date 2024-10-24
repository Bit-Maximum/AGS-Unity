using UnityEngine;
using UnityEngine.InputSystem;


public class TestMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementInput;
    private Animator animator;

    [SerializeField] private float groundSpeed = 10;
    [SerializeField] private float jumpForce = 100;
    [SerializeField] private float characterSize = 8;

    private bool grounded = false;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        movementInput.x = 0f;
        movementInput.y = 0f;
        transform.localScale = new Vector3(characterSize, characterSize, characterSize);
    }

    private void FixedUpdate()
    {
        //body.AddForce(movementInput);
        animator.SetBool("Grounded", grounded);
    }

    private void OnMove(InputValue value)
    {
        float x = value.Get<Vector2>().x;
        float y = value.Get<Vector2>().y;

        Debug.Log("On Move (" + x + ' ' + y);
        ChangeSpriteDirection(x);

        body.velocity = new Vector2(x * groundSpeed, body.velocity.y);
        //movementInput.x = x * groundSpeed;
        if (y > 0) { Jump(); }


        //animator.SetBool("Run", x != 0);
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
            grounded = false;
            animator.SetTrigger("Jump");
        }
    }

    private bool isGrounded()
    {
        return grounded;
    }

    // Flip player sprite when moving left-right
    private void ChangeSpriteDirection(float horisntalAxis) 
    {
        if (horisntalAxis == 0f)
        {

        } else if (horisntalAxis > 0f)
        {
            transform.localScale = new Vector3(characterSize, characterSize, characterSize);
        }
        else
        {
            transform.localScale = new Vector3(-characterSize, characterSize, characterSize);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
            grounded = true;    
    }
}
