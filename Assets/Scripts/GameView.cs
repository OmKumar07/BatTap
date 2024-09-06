using TMPro;
using UnityEngine;
using System.Collections;

public class GameView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public Animator batAnimator;
    private GameModel model;
    public TextMeshProUGUI gameOverScore;
    public GameObject ballTrail;
    public GameObject mainMenuUI;
    public GameObject inGameUI;


    public TextMeshProUGUI chancesText;



    public GameObject fallText;

    public GameObject ball;


    private void Start()
    {
        Time.timeScale = 0.1f;
        model = new GameModel();
        UpdateChances(model.RemainingChances);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        gameOverScore.text = score.ToString();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        ballTrail.SetActive(false);
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }
    public void BatAnimTap()
    {
        batAnimator.SetBool("Down", true);
        batAnimator.SetBool("Up", false);
    }    
    public void BatAnimRelease()
    {
        batAnimator.SetBool("Up", true);
        batAnimator.SetBool("Down", false);
    }
    public void RestartGame() 
    {
        UpdateChances(model.RemainingChances);
        model.ResetGame();
        Time.timeScale = 1;
        model.ResetGame();
        UpdateScore(model.Score);
        HideGameOver();
        ballTrail.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        inGameUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
    public void UpdateChances(int remainingChances)
    {
        chancesText.text = "Chances: " + remainingChances.ToString();
    }
    public IEnumerator fall()
    {
        fallText.SetActive(true);
        ballTrail.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        fallText.SetActive(false);
        ball.transform.position = new Vector2(0,6);
        ballTrail.SetActive(true);
    }
}
