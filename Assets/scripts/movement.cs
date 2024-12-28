using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    void Update()
    {
        // Get input on the horizontal axis (A/D or Left/Right arrow keys)
        float move = Input.GetAxis("Horizontal");

        // Move the player along the X-axis
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);
    }
}
