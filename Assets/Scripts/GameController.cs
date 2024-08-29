using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameModel model;
    private GameView view;

    private void Start()
    {
        view = gameObject.GetComponent<GameView>();
        view.UpdateScore(model.Score);
        view.HideGameOver();
    }

    private void Update()
    {
        if (model.IsGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                model.ResetGame();
                view.UpdateScore(model.Score);
                view.HideGameOver();
            }
        }
    }
}
