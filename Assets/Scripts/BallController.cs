using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public BatController batController;
    public GameController gameController;

    public float bounceForce;
    public float velocityDampingFactor = 0.9f;
    public float heightThreshold = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.y > heightThreshold)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * velocityDampingFactor);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bat")
        {
            Vector3 batVelocity = batController.GetBatVelocity();
            Vector2 force = new Vector2(batVelocity.x, bounceForce);
            rb.AddForce(force, ForceMode2D.Impulse);
            gameController.OnBallHitBat();
        }

        if (collision.gameObject.tag == "Ground")
        {
            gameController.OnBallHitGround();
        }
    }
}
