using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public BatController batController;
    public GameController gameController;

    public float bounceForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bat")
        {
            Vector3 batVelocity = batController.GetBatVelocity();
            Vector2 force = new Vector2(batVelocity.x, Mathf.Abs(batVelocity.y)) * bounceForce; // Adjust the multiplier to scale the force
            rb.AddForce(force, ForceMode2D.Impulse);
            gameController.OnBallHitBat();
        }

        if (collision.gameObject.tag == "Ground")
        {
            gameController.OnBallHitGround();
            Debug.Log("GameOver");
            transform.position = Vector3.zero;
        }
    }
}
