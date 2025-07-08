using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxVertical;
    public float accelVertical;
    public float maxForward;
    public float accelForward;
    public float maxBackward;
    public float accelBackward;

    public Rigidbody2D rb;

    void FixedUpdate()
    {
        // Horizontal Control
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            float newHorizontal = rb.linearVelocity.x + accelForward * Input.GetAxisRaw("Horizontal");
            if (newHorizontal >= maxForward)
            {
                rb.linearVelocity = new Vector2(maxForward, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(newHorizontal, rb.linearVelocity.y);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            float newHorizontal = rb.linearVelocity.x + accelBackward * Input.GetAxisRaw("Horizontal");
            if (newHorizontal <= -maxBackward)
            {
                rb.linearVelocity = new Vector2(-maxBackward, rb.linearVelocity.y);
            }
            else
            {
                rb.linearVelocity = new Vector2(newHorizontal, rb.linearVelocity.y);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            if (rb.linearVelocity.x < 0)
            {
                float newHorizontal = rb.linearVelocity.x +0.5f * accelForward;
                if (newHorizontal >= 0)
                {
                    rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
                }
                else
                {
                    rb.linearVelocity = new Vector2(newHorizontal, rb.linearVelocity.y);
                }
            }
            else if (rb.linearVelocity.x > 0)
            {
                float newHorizontal = rb.linearVelocity.x - 0.5f * accelBackward;
                if (newHorizontal <= 0)
                {
                    rb.linearVelocity = new Vector2(-0, rb.linearVelocity.y);
                }
                else
                {
                    rb.linearVelocity = new Vector2(newHorizontal, rb.linearVelocity.y);
                }
            }
        }

        //Vertical Control
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            float newVertical = rb.linearVelocity.y + accelVertical * Input.GetAxisRaw("Vertical");
            if (newVertical >= maxVertical)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, maxVertical);
            }
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVertical);
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            float newVertical = rb.linearVelocity.y + accelVertical * Input.GetAxisRaw("Vertical");
            if (newVertical <= -maxVertical)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -maxVertical);
            }
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVertical);
            }
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (rb.linearVelocity.y < 0)
            {
                float newVertical = rb.linearVelocity.y + 0.5f * accelForward;
                if (newVertical >= 0)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                }
                else
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVertical);
                }
            }
            else if (rb.linearVelocity.y > 0)
            {
                float newVertical = rb.linearVelocity.y - 0.5f * accelVertical;
                if (newVertical <= 0)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                }
                else
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVertical);
                }
            }
        }
    }
}
