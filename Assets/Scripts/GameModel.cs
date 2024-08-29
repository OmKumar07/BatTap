using UnityEngine;

public class GameModel : MonoBehaviour
{
    public int Score;
    public bool IsGameOver;



    public void ResetGame()
    {
        Score = 0;
        IsGameOver = false;
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void GameOver()
    {
        IsGameOver = true;
    }
}
