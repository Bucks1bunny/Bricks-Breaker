using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [field: SerializeField]
    public BrickManager BrickManager
    {
        get;
        private set;
    }
    [field: SerializeField]
    public ResetBall ResetBall
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject pauseUI = null;
    [SerializeField]
    private GameObject endGameUI = null;
    [SerializeField]
    private TextMeshProUGUI endGameText = null;
    [SerializeField]
    private TextMeshProUGUI scoreText = null;
    [SerializeField]
    private TextMeshProUGUI endScoreText = null;
    private int score = 0;
    private int health = 3;

    private void Start()
    {
        BrickManager.Scored += UpdateScore;
        BrickManager.AllBricksDestoyed += EndGame;
        ResetBall.BallPassed += OnHealthLost;

        Cursor.visible = false;
        pauseUI.SetActive(false);
        endGameUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
            TurnOnCursor();
        }
    }

    private void UpdateScore(int _score)
    {
        score += _score;
        scoreText.text = "Score:" + score.ToString();
    }

    private void EndGame(bool win)
    {
        endGameUI.SetActive(true);
        endScoreText.text = "Score:" + score.ToString();
        TurnOnCursor();
        if (win)
        {
            endGameText.text = "YOU WIN";
        }
        else
        {
            endGameText.text = "GAME OVER";
        }
    }

    private void TurnOnCursor()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    private void OnHealthLost()
    {
        health--;
        if (health == 0)
        {
            EndGame(false);
        }
    }
}
