using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameModel model;
    public GameView view;

    private void Start()
    {
        model = new GameModel();
        view.UpdateScore(model.Score);
        view.HideGameOver();
    }

    private void Update()
    {
        if (model.IsGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                model.ResetGame();
                view.UpdateScore(model.Score);
                view.HideGameOver();
            }
        }
    }

    public void OnBallHitBat()
    {
        model.AddScore(1);
        view.UpdateScore(model.Score);
    }

    public void OnBallHitGround()
    {
        model.GameOver();
        view.ShowGameOver();
        Time.timeScale = 0;
    }
}
