using UnityEngine;

public class BallController : MonoBehaviour
{
    public float bounceForce = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bat")
        {
            rb.velocity = new Vector2(rb.velocity.x, bounceForce);
        }
    }
}
