public class GameModel
{
    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }
    public int RemainingChances { get; private set; }

    public GameModel()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        Score = 0;
        IsGameOver = false;
        RemainingChances = 5;
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void GameOver()
    {
        IsGameOver = true;
    }
    public void LoseChance()
    {
        if (RemainingChances > 0)
        {
            RemainingChances--;
        }
        if (RemainingChances <= 0)
        {
            GameOver();
        }
    }
}
