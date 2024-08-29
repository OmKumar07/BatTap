using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bat")
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            gameController.OnBallHitBat();
        }

        if (collision.gameObject.tag == "Ground")
        {
            gameController.OnBallHitGround();
            transform.position = Vector3.zero;
        }
    }
}
