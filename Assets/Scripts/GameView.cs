using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }
}
