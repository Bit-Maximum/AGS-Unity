using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpReleaseTest : MonoBehaviour
{
    public void OnJumpPress(InputValue value)
    {
        Debug.Log("Spasebar: Pressed");
    }

    public void OnJumpRelease(InputValue value)
    {
        Debug.Log("Spasebar: Release");
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Debug.Log("Move: " + input);
    }

    public void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Debug.Log("Look: " + input);
    }
}
