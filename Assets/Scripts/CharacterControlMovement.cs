using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterControlMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementInput;

    [SerializeField]
    private float forse = 10;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>().normalized;
     
    }

    private void OnColl
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        body.AddForce(movementInput * forse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
