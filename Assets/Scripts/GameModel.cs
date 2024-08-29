public class GameModel
{
    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    public GameModel()
    {
        ResetGame();
    }

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
