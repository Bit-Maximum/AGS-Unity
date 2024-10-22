using UnityEngine;

public class TransforfMovement : MonoBehaviour
{
    private float value;

    private void FixedUpdate()
    {
        value += Time.fixedDeltaTime;
        transform.position = Mathf.Sin(value) * Vector2.one * 3;
    }
}
