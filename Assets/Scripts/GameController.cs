using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameModel model;
    public GameView view;

    private void Start()
    {
        Application.targetFrameRate = 60;
        model = new GameModel();
        view.UpdateScore(model.Score);
        view.HideGameOver();

    }

    public void OnBallHitBat()
    {
        model.AddScore(1);
        view.UpdateScore(model.Score);
    }

    public void OnBallHitGround()
    {
        model.LoseChance();
        view.UpdateChances(model.RemainingChances);
        if (model.RemainingChances <= 0)
        {
            view.ShowGameOver();
            Time.timeScale = 0;
            model.GameOver();
        }
        else
        {
            StartCoroutine(view.fall());
        }
    }
}
