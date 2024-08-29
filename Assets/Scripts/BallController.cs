using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameModel model;
    public GameView view;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bat")
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            model.AddScore(1);
            view.UpdateScore(model.Score);
            Debug.Log("Score+1");
        }
        if (collision.gameObject.tag == "Ground")
        {
           model.GameOver();
           view.ShowGameOver();
           Debug.Log("GameOver");
        transform.position = Vector3.zero;
        }
        
    }
}
